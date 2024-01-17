namespace RecordMedical.Model
{
    public class PasswordManager
    {
      
        public long Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }



  
    }
}
