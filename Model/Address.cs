using System.ComponentModel.DataAnnotations;

namespace RecordMedical.Model
{
    public class Address
    {
        [Key]
        public long AddressId { get; set; }
        public string HouseNo { get; set; }
        public string City {  get; set; }
        public string District { get; set; }
        public string State {  get; set; }
        public int ZipCode { get; set; }
    }
}
