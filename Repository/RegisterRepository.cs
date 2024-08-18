using iStartWeb.Models;
using iStartWebAPI.DbcontextFiles;
using iStartWebAPI.Interface;
using iStartWebAPI.Models;
using Microsoft.Ajax.Utilities;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http.Results;

namespace iStartWebAPI.Repository
{
    public class RegisterRepository : IRegister
    {
        private readonly DbConfig _dbConfig;
        public RegisterRepository(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }
        public IEnumerable<UserRegistration> GetRegisteredUsers()
        {
            return _dbConfig.userRegistrations.ToList();
        }

       
        public HttpResponseMessage AddRegistration(UserRegistration userRegister)
        {
           
            HttpResponseMessage result;

            var emailExist = _dbConfig.userRegistrations.Where(c => c.EmailID == userRegister.EmailID).Select(x=>x.RegisterId).ToList();

            if (emailExist.Count() > 0)
            {
                result = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                var usersAdding = new UserRegistration
                {
                    Name = userRegister.Name,
                    EmailID = userRegister.EmailID,
                    Gender = userRegister.Gender,
                    Password = userRegister.Password,
                    ReEnterPassword = userRegister.ReEnterPassword
                };

                byte[] key = new byte[16];
                byte[] iv = new byte[16];
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                    rng.GetBytes(iv);
                }
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    byte[] plainBytes = Encoding.UTF8.GetBytes(userRegister.Password);
                    string encryptedText = Convert.ToBase64String(plainBytes);
                    userRegister.Password = encryptedText;
                    userRegister.ReEnterPassword = encryptedText;
                    _dbConfig.userRegistrations.Add(userRegister);

                    _dbConfig.SaveChanges();
                }

            }
            if (emailExist.Count()>0)
            {
                result = new HttpResponseMessage(HttpStatusCode.BadRequest);
              
            }
            else
            {

                result = new HttpResponseMessage(HttpStatusCode.OK);
            }
            return result;
        } 
        

        public UserRegisterViewModel EditRegistration(int userId, UserRegisterViewModel usereditValues)
        {

            var retrievedItems = _dbConfig.userRegistrations.FirstOrDefault(x => x.RegisterId == userId);

            if (retrievedItems != null)
            {
                retrievedItems.Name=usereditValues.Name;

            }
            _dbConfig.SaveChanges();
            return usereditValues;
        }
    }
}