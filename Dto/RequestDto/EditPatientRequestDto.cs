using RecordMedical.Model;

namespace RecordMedical.Dto.RequestDto
{
    public class EditPatientRequestDto
    {

        public long PatientId { get; set; } 
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public int Gender { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReportingTime { get; set; }



        public Address Address { get; set; }




        public long DoctorId { get; set; }
    }
}
