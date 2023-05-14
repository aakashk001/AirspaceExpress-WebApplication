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
    public class AdminController : Controller
    {
        AirspaceExpressRepository repository;
        public AdminController()
        {
            repository = new AirspaceExpressRepository();
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<UserData> userData = new List<UserData>();
            try
            {
                userData = repository.GetAllUsers();
            }
            catch (Exception)
            {


                userData = null;
            }
            return Json(userData);
        }

        

    }
}
