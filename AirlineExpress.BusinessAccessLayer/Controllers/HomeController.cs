using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirspaceExpress.DataAccessLayer.Models;
using AirspaceExpress.DataAccessLayer;          
namespace AirlineExpress.BusinessAccessLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        AirspaceExpressRepository repository;
        public HomeController()
        {
            repository = new AirspaceExpressRepository();
        }

        [HttpGet]
        public JsonResult AuthenticateUser(string emailId, string password)
        {
            int value = 0;
            string result = null;
            try
            {
              value  = repository.Authenticate_User(emailId, password);
                if(value == -1)
                {
                    result = emailId + " is not registered";
                }
                else if(value == -2)
                {
                    result = "Invalid Credentails";
                }
                else if(value == 1)
                {
                    result = "Successfull Login";
                }
                else
                {
                    result = "Something Went Wrong!!!!!!!!!!!";
                }
            }
            catch (Exception)
            {

                result = "Something Went Wrong";
            }
            return Json(result);

        }
    }
}
