using System.Text.RegularExpressions;

namespace RecordMedical.Utility
{
    public class ValidationUtility
    {

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use the built-in MailAddress class for email validation
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            // Define the password requirements: at least 8 characters, with a mix of uppercase, lowercase, digit, and special character
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

            return regex.IsMatch(password);
        }
    }
}
