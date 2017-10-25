using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Configuration;


namespace Capstone.Web.DAL
{
    public interface iNPDAL
    {
        List<ParkModel> GetAllParks();
        ParkModel GetParkFromCode(string parkCode);
        List<WeatherModel> GetWeather(string parkCode);
        bool SaveSurvey(SurveyModel survey);
        ParkModel GetMostPopularPark();

    }
}