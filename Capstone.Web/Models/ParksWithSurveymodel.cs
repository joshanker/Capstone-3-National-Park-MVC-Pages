using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParksWithSurveyModel
    {
        public SurveyModel Survey;
        public List<ParkModel> Parks;

        public ParksWithSurveyModel() { }

        public ParksWithSurveyModel(SurveyModel survey, List<ParkModel> parks)
        {
            this.Survey = survey;
            this.Parks = parks;

        }

    }
}