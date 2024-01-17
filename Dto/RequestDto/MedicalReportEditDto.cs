namespace RecordMedical.Dto.RequestDto
{
    public class MedicalReportEditDto
    {
        public long MedicalReportId { get; set; }

        public string MedicalReport_Name { get; set; }
        public IFormFile ModifiedFile { get; set; }
    }
}
