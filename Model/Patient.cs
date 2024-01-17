using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecordMedical.Model
{
    public class Patient
    {
        [Key]
        public long PatientId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

    
        public int Gender { get; set; }

        public string Email {  get; set; }
        public string Phone { get; set; }
        public DateTime ReportingTime { get; set; }

           public Attendee Attendee { get; set; }
  
        public Address Address { get; set; }
     
        public List<MedicalReport> MedicalReports { get; set; } =new List<MedicalReport> { };


        public Doctor Doctor { get; set; }
     



    }
}
