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

         var returnval = repository.Authenticate_User("tom123@gmail.com", "tom@123");
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
