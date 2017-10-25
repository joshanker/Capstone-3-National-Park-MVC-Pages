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
        

        public double FtoC(double temp)
        {
            double c = .55 * (temp - 32);
            int c2 = Convert.ToInt32(c);
            return c2;
        }
        



    }
}