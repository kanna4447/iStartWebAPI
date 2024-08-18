using iStartWeb.Models;
using iStartWebAPI.DbcontextFiles;
using iStartWebAPI.Interface;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;


namespace iStartWebAPI.Repository
{
    public class LoginRepository : ILogin
    {
        private readonly DbConfig _dbConfig;
        public LoginRepository(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }
        public HttpResponseMessage UserLoginCheck(UserRegisterViewModel userlogin)
        {
            HttpResponseMessage result;
            var getregisteredUsers = _dbConfig.userRegistrations.ToList();
                var values = string.Empty;

                bool isvalid = false;
           
                foreach (var item in getregisteredUsers)
                {

                    isvalid = item.EmailID == userlogin.EmailID;

                values = item.Password;
                    if (isvalid == true)
                    {
                        break;
                    }

                }
            

                if (isvalid == true)
                {
                    byte[] encryptedPassword = Convert.FromBase64String(values);
                    string decryptedPassword = Encoding.UTF8.GetString(encryptedPassword);
                isvalid = decryptedPassword == userlogin.Password;
                }
            

           if (isvalid == true)
            {
                
               result = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
               
                 result = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
           

            return result;

        }



    }
}