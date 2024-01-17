namespace RecordMedical.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public PasswordManager PasswordManager { get; set; }

        public DateTime JoiningDate { get; set; }

    }
}
