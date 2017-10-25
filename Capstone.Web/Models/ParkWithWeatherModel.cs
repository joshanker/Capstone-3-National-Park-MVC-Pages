using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkWithWeatherModel
    {

        public ParkModel Park;
        public List<WeatherModel> Weather;
        


        public ParkWithWeatherModel(ParkModel park, List<WeatherModel> weather)
        {
            this.Park = park;
            this.Weather = weather;

        }




    }
}