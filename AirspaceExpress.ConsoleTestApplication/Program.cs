using System;
using AirspaceExpress.DataAccessLayer;
namespace AirspaceExpress.ConsoleTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           var repository = new AirspaceExpressRepository();
            //var users =  repository.GetAllUsers();
            //foreach(var user in users)
            // {
            //     Console.WriteLine("{0}\t\t{1}",user.EmailId, user.UserName);

            // }

         var returnval = repository.Authenticate_User("maria10@gmail.com", "maria_10");
            if(returnval == 1)
            {
                Console.WriteLine("Login Successfull");
            }
            else
            {
                Console.WriteLine("Invalid Credentails");
            }
            
        }
    }
}
