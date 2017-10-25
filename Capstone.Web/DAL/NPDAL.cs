using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Configuration;
using Capstone.Web.DAL;


namespace Capstone.Web
{
    public class NPDAL : iNPDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NPGeekDB"].ConnectionString;
        List<ParkModel> parkList = new List<ParkModel>();
        ParkModel park = new ParkModel();
        WeatherModel weather = new WeatherModel();
        List<WeatherModel> weatherList = new List<WeatherModel>();
        private const string SQL_GetAllParks = "select * from park";
        private const string SQL_GetParkFromCode = "select * from park where parkCode = @parkCode";
        private const string SQL_GetWeatherFromParkCode = "select * from weather where parkCode = @parkCode";
        private const string SQL_SaveSurvey = "insert into survey_result values (@parkCode, @email, @state, @activitylevel)";
        private const string SQL_GetMostPopularPark = "select top 1 parkCode from survey_result group by parkCode order by COUNT(parkCode) desc";

        public List<ParkModel> GetAllParks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParkModel p = new ParkModel();
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        parkList.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return parkList;
        }

        public ParkModel GetParkFromCode(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetParkFromCode, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParkModel p = new ParkModel();
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        park = p;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return park;
        }

        public List<WeatherModel> GetWeather(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetWeatherFromParkCode, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        WeatherModel w = new WeatherModel();
                        
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);
                        w.ParkCode = Convert.ToString(reader["parkCode"]);

                        
                        weatherList.Add(w);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return weatherList;

        }

        public bool SaveSurvey(SurveyModel survey)
        {


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@email", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activitylevel", survey.ActivityLevel);
                    int rowsAffected=cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            
        }

        public ParkModel GetMostPopularPark()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetMostPopularPark, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string winner= Convert.ToString(reader["parkCode"]);

                        NPDAL newDAL = new NPDAL();

                        ParkModel p = newDAL.GetParkFromCode(winner);
                        
                        park = p;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return park;


        }
    }
}
