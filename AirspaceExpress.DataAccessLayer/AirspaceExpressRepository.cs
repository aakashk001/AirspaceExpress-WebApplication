using System;
using System.Collections.Generic;
using System.Text;
using AirspaceExpress.DataAccessLayer.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace AirspaceExpress.DataAccessLayer
{
  public class AirspaceExpressRepository
    {
        AirspaceExpressContext context;
        public AirspaceExpressRepository()
        {
            context = new AirspaceExpressContext();
        }

        public List<UserData> GetAllUsers()
        {
            var users = (from user in context.UserData select user).ToList();
            return users;
        }

        public int Authenticate_User(string emailId , string password)
        {
            int result = 0;
            int returnVal = 0;
            SqlParameter prmEmailId = new SqlParameter("@EmailId", emailId);
            SqlParameter prmPassword = new SqlParameter("@Password", password);
            SqlParameter prmResult = new SqlParameter("@Return", System.Data.SqlDbType.Int);
            prmResult.Direction = System.Data.ParameterDirection.Output;
            result = context.Database.ExecuteSqlRaw("EXEC @Return = usp_ValidateCredentials @EmailId,@Password",prmResult, prmEmailId, prmPassword);
            returnVal = Convert.ToInt32(prmResult.Value);
            return returnVal;
        }


       
    }
}
