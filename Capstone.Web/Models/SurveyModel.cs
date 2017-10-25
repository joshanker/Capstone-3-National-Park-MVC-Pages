using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }
        [Required(ErrorMessage ="Please select your favorite park")]
        public string ParkCode { get; set; }
        [Required(ErrorMessage = "Please enter your eMail address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter your state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please select your activity level")]
        [Display(Name ="Activity Level:")]
        public string ActivityLevel { get; set; }
        


    }
}