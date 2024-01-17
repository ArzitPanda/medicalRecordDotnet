using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecordMedical.Dto.RequestDto;
using RecordMedical.Dto.ResponseDto;
using RecordMedical.Model;
using RecordMedical.Services.MedicalReportServices;

namespace RecordMedical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalReportController : ControllerBase
    {
        private readonly IMedicalReportService _mediicalReportService;
            public MedicalReportController(IMedicalReportService medicalReportService) {
            _mediicalReportService = medicalReportService;
                
        }


        [HttpPost]
        public async Task<ActionResult<MedicalReport>> CreateMedicalReport([FromForm]MedicalReportRequestDto medicalReport)
        {

            Console.WriteLine(medicalReport.MedicalReport_Name);
            Console.WriteLine(medicalReport.PatientId);
            Console.WriteLine(medicalReport.Created);
            Console.WriteLine(medicalReport.formFile.FileName);
         try
            {
                MedicalReport a = await _mediicalReportService.CreateMedicalReport(medicalReport);
                return Ok(a);
            }
            catch (Exception ex)
            {

               return Unauthorized(ex.Message);
            }

            


        }



        [HttpGet("patient")]
        public async Task<ActionResult<MedicalRecordPageDto>> GetMedicalPageReprtByPatient(long patientid,int pageNo,int pageSize)
        {

            try
            {
                MedicalRecordPageDto medicalRecordPageDto = await _mediicalReportService.GetMedicalReportByPatientIdAsync(patientid, pageNo, pageSize);
                return Ok(medicalRecordPageDto);
            }
            catch (Exception ex)
            {

                return Unauthorized(ex.Message);
            }


        }

        [HttpPut]
        public async Task<ActionResult<MedicalReport>> UpdateMedicalRecord(MedicalReportEditDto medicalReportEditDto)
        {

            try
            {
                MedicalReport medicalReport  = await _mediicalReportService.UpdateMedicalReport(medicalReportEditDto);
                return Ok(medicalReport);

            }
            catch(Exception ex) 
            {
                return Unauthorized(ex.Message);
            }


        }



    }
}
