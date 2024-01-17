using System.ComponentModel.DataAnnotations;

namespace RecordMedical.Model
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string Name { get; set; }

        public String Specialist { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();


    }
}
