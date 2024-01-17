using RecordMedical.Model;

namespace RecordMedical.Dto.ResponseDto
{
    public class PatientPageDto : PageDto
    {
       
        public List<Patient> Page { get; set; }

    }
}
