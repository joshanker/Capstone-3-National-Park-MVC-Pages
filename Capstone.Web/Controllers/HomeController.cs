using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        //NPDAL dal = new NPDAL();
        iNPDAL dal = new NPDAL();
        public HomeController(iNPDAL npdal)
        {
            this.dal = npdal;
        }


        // GET: Home
        public ActionResult Index()
        {
           
            List<ParkModel> model = dal.GetAllParks();

            return View("Index", model);
        }
        
        public ActionResult Detail(string parkCode)
        {

            List<WeatherModel> wmodel = dal.GetWeather(parkCode);
            ParkModel pmodel = dal.GetParkFromCode(parkCode);
            ParkWithWeatherModel model = new ParkWithWeatherModel(pmodel, wmodel);
            
            return View("Detail", model);
        }


    }
}