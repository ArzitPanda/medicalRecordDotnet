namespace RecordMedical.Dto.ResponseDto
{
    public class PageDto
    {

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
