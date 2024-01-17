using RecordMedical.Model;

namespace RecordMedical.Dto.RequestDto
{
    public class MedicalReportRequestDto
    {

        public string MedicalReport_Name { get; set; }
        public IFormFile formFile { get; set; }


        
        public long PatientId { get; set; }
        public DateTime Created { get; set; }

    }
}
