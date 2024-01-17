using System.ComponentModel.DataAnnotations;

namespace RecordMedical.Model
{
    public class Attendee
    {
       
        public int Id { get; set; }
        public string Name { get ; set; } =string.Empty;
        public RelationShip Relation { get; set; }
        public string PhoneNumber {  get; set; }    = string.Empty;

    }
}
