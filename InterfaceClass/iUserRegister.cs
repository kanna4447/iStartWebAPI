using iStartWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStartWebAPI.InterfaceClass
{
    public interface iUserRegister
    {
        //, string passwordvalidate, out string ErrorMessage
        int AddRegistration(UserRegistration userRegister);
        List<UserRegistration> GetRegisteredUsers();

       //UserRegistration GetRegisteredUserById(int registereduserId );
       // UserRegistration EditRegisteredUser(int registereduserId ,UserRegistration userRegister);

       // int DeleteRegisteredUser(int registereduserId);




    }
}
