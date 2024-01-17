using RecordMedical.Model;
using System.Text.Json.Serialization;

namespace RecordMedical.Dto.RequestDto
{
    public class AddPatientDto
    {
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public int Gender { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReportingTime { get; set; }

        public Attendee Attendee { get; set; }

        public Address Address { get; set; }
     
    

    
        public long DoctorId { get; set; }
    }
}
