using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RecordMedical.DataContext;
using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;

namespace RecordMedical.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly RecordDbContext _recordDbContext;
        public PatientService(RecordDbContext recordDbContext)
        {
            _recordDbContext = recordDbContext;

        }

        public async Task<Patient> CreatePatientAsync(AddPatientDto patient)
        {
            Address a = patient.Address;
            await _recordDbContext.Addresses.AddAsync(a);
            await _recordDbContext.SaveChangesAsync();
            long addressId = a.AddressId;

            Patient p = new Patient();

            p.Address = a;
            p.Address = patient.Address;
            p.Email = patient.Email;
            p.Phone = patient.Phone;
            p.FirstName = patient.FirstName;
            p.LastName = patient.LastName;
            p.ReportingTime = patient.ReportingTime;

            Console.WriteLine($"dpctor id is {patient.DoctorId}");
            Doctor r = await _recordDbContext.Doctors.FirstOrDefaultAsync(a => a.DoctorId == 2);
            if (r is null)
            {
                throw new Exception("doctor is not found");
            }
            p.Doctor = r;

            Attendee attendee = new Attendee { Name=patient.Attendee.Name,PhoneNumber=patient.Attendee.PhoneNumber , Relation=patient.Attendee.Relation
            };

            await _recordDbContext.Attendees.AddAsync(attendee);

            p.Attendee = attendee;

            await _recordDbContext.Patient.AddAsync(p);
            await _recordDbContext.SaveChangesAsync();
            return p;

        }

        public async Task<Patient> GetPatientAsync(long id)
        {

            Patient p = await _recordDbContext.Patient
                  .Include(p => p.Address)
              .Include(p => p.MedicalReports)
               .Include(p => p.Doctor)
               .Include(p=>p.Attendee)
              .FirstOrDefaultAsync(a => a.PatientId == id);
            if (p is null)
            {
                throw new Exception("not found");
            }
            return p;


        }

        public async Task<PatientPageDto> GetPatientsByNameAsync(string patient, int pageNo, int pageSize)
        {
            if (pageNo <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Invalid pageNo or pageSize");
            }

            // Query the database
            var query = _recordDbContext.Patient
                .Where(p => EF.Functions.Like(p.FirstName, $"%{patient}%") || EF.Functions.Like(p.LastName, $"%{patient}%"))
                .OrderBy(p => p.PatientId);

            // Calculate total items
            var totalItems = await query.CountAsync();

            // Calculate total pages
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Ensure pageNo is within valid range
            pageNo = Math.Max(1, Math.Min(pageNo, totalPages));

            // Apply pagination
            var patients = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Create the PatientPageDto
            PatientPageDto patientPageDtoOne = new PatientPageDto
            {
                CurrentPage = pageNo,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems,
                Page = patients
            };

            return patientPageDtoOne;
        }

        public async Task<Patient> UpdatePatientAsync(EditPatientRequestDto editPatientRequest)
        {
            Patient p = await _recordDbContext.Patient.Include(p => p.Address).Include(p => p.Doctor).FirstOrDefaultAsync(a => a.PatientId == editPatientRequest.PatientId);
            if (p == null)
            {
                throw new Exception("Patient is not found");
            }


            Doctor d = await _recordDbContext.Doctors.FirstOrDefaultAsync(a => a.DoctorId == editPatientRequest.DoctorId);

            if (d == null)
            {
                throw new Exception("doctor is not found");
            }

            p.Address.State = editPatientRequest.Address.State;
            p.Address.ZipCode = editPatientRequest.Address.ZipCode;
            p.Address.City = editPatientRequest.Address.City;
            p.Address.HouseNo = editPatientRequest.Address.HouseNo;
            p.Address.District = editPatientRequest.Address.District;
            p.Doctor = d;
            p.Email = editPatientRequest.Email;
            p.ReportingTime = editPatientRequest.ReportingTime;
            p.FirstName = editPatientRequest.FirstName;
            p.LastName = editPatientRequest.LastName;
            p.Phone = editPatientRequest.Phone;

            await _recordDbContext.SaveChangesAsync();
            return p;

        }
    }
}
