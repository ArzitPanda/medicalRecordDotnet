using RecordMedical.Model;

namespace RecordMedical.Dto.ResponseDto
{
    public class PatientResponseDto
    {

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public int Gender { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReportingTime { get; set; }

        public Attendee Attendee { get; set; }

        public Address Address { get; set; }

       
    }
}
