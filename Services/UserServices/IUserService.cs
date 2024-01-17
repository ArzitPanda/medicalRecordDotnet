using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;

namespace RecordMedical.Services.UserServices

{
    public interface IUserService
    {
        public Task<UserResponseDto> SignUp(UserRequestDto userRequestDto);
        public Task<string> Login(string email,string password);

        public Task<User> GetUser(int id);


    }
}
