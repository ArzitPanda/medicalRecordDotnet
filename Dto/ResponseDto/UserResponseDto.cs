using RecordMedical.Model;

namespace RecordMedical.Dto.ResponseDto
{
    public class UserResponseDto
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime JoiningDate { get; set; }


    }
}
