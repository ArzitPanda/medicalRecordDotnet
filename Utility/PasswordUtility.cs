using System.Security.Cryptography;

namespace RecordMedical.Utility
{
    public class PasswordUtility
    {
        public static  void createPassword(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var a = new HMACSHA512())
            {
                passwordSalt = a.Key;
                 passwordHash=  a.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }

        }


        public static  bool checkPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var a = new HMACSHA512(passwordSalt))
            {
               
              return  a.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)).SequenceEqual(passwordHash);
                
            }



        }


    }
}
