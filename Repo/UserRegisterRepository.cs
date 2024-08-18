using iStartWebAPI.DbcontextFiles;
using iStartWebAPI.InterfaceClass;
using iStartWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace iStartWebAPI.Repo
{
    public class UserRegisterRepository
    {
        private readonly Dbconfig _context;
        public UserRegisterRepository(Dbconfig Context)
        {
            _context = Context;
        }

       // out string ErrorMessage

        public int AddRegistration(UserRegistration userRegister)
        {

            // input = userRegister.Password;
            
                //ErrorMessage = string.Empty;

                //if (string.IsNullOrWhiteSpace(input))
                //{
                //    throw new Exception("Password should not be empty");
                //}

                //var hasNumber = new Regex(@"[0-9]+");
                //var hasUpperChar = new Regex(@"[A-Z]+");
                //var hasSymbols = new Regex("^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$");


                //if (!hasUpperChar.IsMatch(input))
                //{
                //    ErrorMessage = "Password should contain At least one upper case letter";

                //}

                //else if (!hasNumber.IsMatch(input))
                //{
                //    ErrorMessage = "Password should contain At least one numeric value";

                //}

                //else if (!hasSymbols.IsMatch(input))
                //{
                //    ErrorMessage = "Password should contain At least one special case characters";

                //}

                Aes aes = Aes.Create();
                aes.KeySize = 256;
                aes.Mode = CipherMode.CBC;
                aes.GenerateKey();
                aes.GenerateIV();

                string password = userRegister.Password;
            
            string cpass = userRegister.ReEnterPassword;
            password = cpass;

            byte[] ciphertext;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] plaintextBytes = Encoding.UTF8.GetBytes(password);
                    ciphertext = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
                }

                string decryptedText;

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                    decryptedText = Encoding.UTF8.GetString(decryptedBytes);
                }

           
                _context.userRegistrations.Add(userRegister);
             var s=   _context.SaveChanges();
            return s;

            
           
        }

        public List<UserRegistration> GetRegisteredUsers()
        {
            throw new NotImplementedException();
        }





        //public bool ValidatePassword(string password, out string ErrorMessage)
        //{
        //    var input = password;
        //    ErrorMessage = string.Empty;

        //    if (string.IsNullOrWhiteSpace(input))
        //    {
        //        throw new Exception("Password should not be empty");
        //    }

        //    var hasNumber = new Regex(@"[0-9]+");
        //    var hasUpperChar = new Regex(@"[A-Z]+");
        //    var hasSymbols = new Regex("^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$");


        //     if (!hasUpperChar.IsMatch(input))
        //    {
        //        ErrorMessage = "Password should contain At least one upper case letter";
        //        return false;
        //    }

        //    else if (!hasNumber.IsMatch(input))
        //    {
        //        ErrorMessage = "Password should contain At least one numeric value";
        //        return false;
        //    }

        //    else if (!hasSymbols.IsMatch(input))
        //    {
        //        ErrorMessage = "Password should contain At least one special case characters";
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public int DeleteRegisteredUser(int registereduserId)
        //{
        //    throw new NotImplementedException();
        //}

        //public UserRegistration EditRegisteredUser(int registereduserId, UserRegistration userRegister)
        //{
        //    throw new NotImplementedException();
        //}

        //public UserRegistration GetRegisteredUserById(int registereduserId)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<UserRegistration> GetRegisteredUsers()
        //{
        //    throw new NotImplementedException();
        //}
    }
}