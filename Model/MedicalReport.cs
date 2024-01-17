namespace RecordMedical.Model
{
    public class MedicalReport
    {
        public long MedicalReportId { get; set; }
        public string MedicalReport_Name { get; set; }
        public  string MediacalReport_Url { get; set; }


        public Patient Patient { get; set; }
        public long PatientId { get; set; } 
        public DateTime Created { get; set; }

    }
}
