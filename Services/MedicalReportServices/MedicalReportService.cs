using Microsoft.EntityFrameworkCore;
using RecordMedical.DataContext;
using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;
using RecordMedical.Utility;

namespace RecordMedical.Services.MedicalReportServices
{
    public class MedicalReportService : IMedicalReportService
    {
        private readonly RecordDbContext _recordDbContext;

        private readonly FileUploadUtility _fileUploadUtility;
        public MedicalReportService(RecordDbContext recordDbContext, FileUploadUtility utility)
        {

            _recordDbContext = recordDbContext;
            _fileUploadUtility = utility;


        }


        public async Task<MedicalReport> CreateMedicalReport(MedicalReportRequestDto report)
        {


            Patient p = await _recordDbContext.Patient.FirstOrDefaultAsync(a => a.PatientId == report.PatientId);

            if (p is null)
            {
                throw new Exception("patient is not found");
            }

            try
            {





                string a = await _fileUploadUtility.UploadFileAsync(report.formFile, "medical_name");
                MedicalReport medicalReport = new MedicalReport { Created = DateTime.Now, MediacalReport_Url = a, MedicalReport_Name = report.MedicalReport_Name, Patient = p, PatientId = p.PatientId };
                await _recordDbContext.MedicalReport.AddAsync(medicalReport);
                await _recordDbContext.SaveChangesAsync();


                return medicalReport;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }

        public Task<MedicalReport> GetMedicalReportById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<MedicalRecordPageDto> GetMedicalReportByPatientIdAsync(long id, int pageNo, int pageSize)
        {

            Patient p = await _recordDbContext.Patient.FirstOrDefaultAsync(a => a.PatientId == id);
            if (p is null)
            {
                throw new Exception("patient not found");
            }

            if (pageSize < 0)
            {
                pageSize = 10;
            }

            int totalRecord = await _recordDbContext.MedicalReport.Where(a => a.PatientId == id).CountAsync();

            int totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            int curPageNo = Math.Max(1, Math.Min(totalPage, pageNo));

            List<MedicalReport> query = await _recordDbContext.MedicalReport.Skip((curPageNo - 1) * pageSize)
                .Take(pageSize)
                .Where(p => p.PatientId == id)
                .ToListAsync();


            MedicalRecordPageDto medicalPageRecordDto = new MedicalRecordPageDto
            {
                CurrentPage = curPageNo,
                Page = query,
                PageSize = pageSize,
                TotalItems = totalRecord,
                TotalPages = totalPage,



            };


            return medicalPageRecordDto;


        }

        public async Task<MedicalReport> UpdateMedicalReport(MedicalReportEditDto report)
        {
                MedicalReport medicalReport  = await _recordDbContext.MedicalReport.FirstOrDefaultAsync(a=>a.MedicalReportId==report.MedicalReportId);   

            if(medicalReport == null)
            {
                throw new Exception("MEDICAL REPORT IS NOT FOUND");
            }

            if(File.Exists(medicalReport.MediacalReport_Url))
            {

                File.Delete(medicalReport.MediacalReport_Url);
                

            }

            string modified_url = await _fileUploadUtility.UploadFileAsync(report.ModifiedFile,report.MedicalReport_Name);
            medicalReport.MediacalReport_Url = modified_url;
            medicalReport.MedicalReport_Name =report.MedicalReport_Name;
            await _recordDbContext.SaveChangesAsync();

            return medicalReport;
        
        }
    }
}
