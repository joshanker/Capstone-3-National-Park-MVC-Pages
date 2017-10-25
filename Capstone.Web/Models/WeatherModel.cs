using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherModel
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        

        public double FtoC(int temp)
        {
            double c = (5 / 9) * (temp - 32);


            return c;
        }
        



    }
}