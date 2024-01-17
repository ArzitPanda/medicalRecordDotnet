using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;
using RecordMedical.Services.PatientServices;

namespace RecordMedical.Controllers
{
    [Authorize(Roles ="user")]
    [Route("api/[controller]")]
    [ApiController]
  
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _patientService;



        public PatientController(IPatientService patientService) {
        
                _patientService = patientService;
        
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(AddPatientDto patient)
        {
               Patient p =   await   _patientService.CreatePatientAsync(patient);

            if (p is null)
            {
                return Unauthorized();
            }
            else
            {
                long createdPatientId = p.PatientId; // Replace with the actual ID

                return CreatedAtAction(nameof(GetPatientById), new { id = createdPatientId }, p);
            }

        }


        [HttpGet]
        public async Task<ActionResult<Patient>> GetPatientById(long id)
        {
            try
            {
                Patient p = await _patientService.GetPatientAsync(id);
                return Ok(p);

            }
            catch (Exception ex)
            {
                return NotFound();

            }
      


        }


        [HttpGet("name")]
        public async Task<ActionResult<PatientPageDto>> GetPatientByName(string name,int pageNo,int pageSize)
        {
            PatientPageDto patientPageDto = await _patientService.GetPatientsByNameAsync(name, pageNo, pageSize);

            if(patientPageDto is null)
            {
                return Unauthorized();
            }
            return Ok(patientPageDto);


        }


        [HttpPut]
        public async Task<ActionResult<Patient>> UpdatePatient(EditPatientRequestDto editPatientRequestDto)
        {
            Patient p = await _patientService.UpdatePatientAsync(editPatientRequestDto);
            if(p is null)
            {
                return Unauthorized();
            }
            return Ok(p);


        }
    }
}
