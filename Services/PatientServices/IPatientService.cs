using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;

namespace RecordMedical.Services.PatientServices
{
    public interface IPatientService
    {

        public Task<Patient> CreatePatientAsync(AddPatientDto patient);
        public Task<PatientPageDto> GetPatientsByNameAsync(string patient,int pageNo ,int pageSize);

        public Task<Patient> GetPatientAsync(long id);

   
        

        public Task<Patient> UpdatePatientAsync(EditPatientRequestDto editPatientRequest);
      


    }
}
