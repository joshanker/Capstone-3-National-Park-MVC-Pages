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

        public ActionResult Detail(string parkCode = "", bool WantsC = false)
        {

            //if (parkCode == "")
            //{
            //    return RedirectToAction("Index");
            //}


            Session["WantsC"] = WantsC;
            List<WeatherModel> wmodel = dal.GetWeather(parkCode);
            ParkModel pmodel = dal.GetParkFromCode(parkCode);
            ParkWithWeatherModel model = new ParkWithWeatherModel(pmodel, wmodel);
            
            return View("Detail", model);
        }

        public ActionResult Survey()
        {
            SurveyModel model = new SurveyModel();
            return View("Survey", model);
        }

        [HttpPost]
        public ActionResult Survey(SurveyModel survey)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Survey");
            }
            else
            {
                dal.SaveSurvey(survey);
            }

            return RedirectToAction("SurveyResult");
        }


        public ActionResult SurveyResult()
        {
            ParkModel model = dal.GetMostPopularPark();


            return View("SurveyResult", model);
        }


    }
}