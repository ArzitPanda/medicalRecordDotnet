using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;

namespace RecordMedical.Services.MedicalReportServices
{
    public interface IMedicalReportService
    {
        public Task<MedicalReport> CreateMedicalReport(MedicalReportRequestDto report);
        public Task<MedicalReport> GetMedicalReportById(long id);
        public Task<MedicalReport> UpdateMedicalReport( MedicalReportEditDto report);

        public Task<MedicalRecordPageDto> GetMedicalReportByPatientIdAsync(long id,int pageNo,int pageSize);
    }
}
