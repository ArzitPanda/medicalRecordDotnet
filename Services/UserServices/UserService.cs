using Microsoft.EntityFrameworkCore;
using RecordMedical.DataContext;
using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;
using RecordMedical.Services.UserServices;
using RecordMedical.Utility;

namespace RecordMedical.Services.UserServices
{
    public class UserService : IUserService
    {

        private readonly RecordDbContext _recordDbContext;
        private readonly TokenUtility _tokenUtility;

        public UserService(RecordDbContext recordDbContext,TokenUtility tokenUtility) {
        
            _recordDbContext = recordDbContext;
            _tokenUtility = tokenUtility;
        
        
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string email, string password)
        {
          
            if(!ValidationUtility.IsValidEmail(email)) {
                throw new Exception("INVALID EMAIL");
            }

              User user = await  _recordDbContext.Users.Include(a=>a.PasswordManager).FirstOrDefaultAsync(a => a.Email == email);
                if(user == null)
                    {
                throw new Exception("User is not found");
                    }

            bool checkPassword = PasswordUtility.checkPassword(password, user.PasswordManager.PasswordHash, user.PasswordManager.PasswordSalt);
            if(!checkPassword)
            {
                throw new Exception("Password is wrong");
            }

              string token =   _tokenUtility.TokenGeneration(user.Id, "User", user.Name);
            return token;



        }

        public async Task<UserResponseDto> SignUp(UserRequestDto userRequestDto)
        {
            string password = userRequestDto.Password;



            if (!ValidationUtility.IsValidEmail(userRequestDto.Email))
            {
                throw new Exception("INVALID EMAIL");
            }

            if(!ValidationUtility.IsStrongPassword(password))
            {
                throw new Exception("give strong password");

            }

            PasswordUtility.createPassword(password,out byte[] passwordHash,out byte[] salt);

            PasswordManager passwordManager = new PasswordManager { PasswordHash=passwordHash,PasswordSalt=salt};
            await _recordDbContext.PasswordManagers.AddAsync(passwordManager);

            User a = new User { Email = userRequestDto.Email, JoiningDate = new DateTime(), Name = userRequestDto.Name, Phone = userRequestDto.Phone, PasswordManager = passwordManager };
           await  _recordDbContext.Users.AddAsync(a);
         await    _recordDbContext.SaveChangesAsync();

            return new UserResponseDto
            {
                Email = userRequestDto.Email,
                Phone = userRequestDto.Phone,
                Id = a.Id,
                JoiningDate = a.JoiningDate,
                Name = a.Name,
            };


        }
    }
}
