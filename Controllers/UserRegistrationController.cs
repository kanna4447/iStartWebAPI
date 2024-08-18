using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using iStartWeb.Models;
using iStartWebAPI.Interface;
using iStartWebAPI.Models;


namespace iStartWebAPI.Controllers
{
   
    public class UserRegistrationController : ApiController
    {
       private readonly IRegister _iRegister;
       

        public UserRegistrationController(IRegister iRegister)
        {
            _iRegister = iRegister;
        }

        public IEnumerable<UserRegistration> GetRegisterUsers()
        {
          var resultregisteredUsers =  _iRegister.GetRegisteredUsers();
            return resultregisteredUsers;

        }

       
            public HttpResponseMessage RegisterAdd(UserRegistration userRegister)
               {
                var resultaddRegister = _iRegister.AddRegistration(userRegister);
            
            return resultaddRegister;
        }
        

 public UserRegisterViewModel EditRegistration(int userId, UserRegisterViewModel usereditValues)
        {
            var resulteditRegister = _iRegister.EditRegistration(userId,usereditValues);

            return resulteditRegister;
        }
    }
}
         
        

    
