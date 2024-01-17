using RecordMedical.Model;

namespace RecordMedical.Dto.ResponseDto
{
    public class MedicalRecordPageDto :PageDto
    {
     public List<MedicalReport> Page { get; set; }

    }
}
