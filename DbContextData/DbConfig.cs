using iStartWebAPI.Models;
using System.Data.Entity;


namespace iStartWebAPI.DbcontextFiles
{
    public class DbConfig :DbContext
    {

        public DbConfig():base("name=DbConnection")
        {
                
        }
        public DbSet<UserLogin> userLogins { get; set; }    
        public DbSet<UserRegistration> userRegistrations { get; set; }   
    }
}