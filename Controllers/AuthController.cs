using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Services.UserServices;

namespace RecordMedical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService) {
           _userService = userService;
        
        }

        [HttpPost]
        public async  Task<ActionResult<UserResponseDto>> SignUp (UserRequestDto userRequestDto)
        {
               try
            {
                 UserResponseDto user = await   _userService.SignUp(userRequestDto);

                return Ok(user);
            }
           catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }




        [HttpGet]
        public async Task<ActionResult<string>> Login (string email ,string password)
        {
            try
            {
                string token = await _userService.Login(email, password);
                return Ok(token);
            }
            catch(Exception ex)
            {
               return Unauthorized(ex.Message); 

            }
                

        }
    }
}
