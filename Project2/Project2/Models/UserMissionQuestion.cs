using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class UserMissionQuestion
    {
        //the attributes from three tables combined into one class to be able to access all the needed data with a query statement
    
        public int MissionID { get; set; }
        [Display(Name ="Mission Name")]
        public string MissionName { get; set; }
        [Display(Name = "Mission President")]
        public string MissionPresident { get; set; }
        public string MissionAddress { get; set; }
        public string MissionCity { get; set; }
        public string MissionCountry { get; set; }
        public string DominantReligion { get; set; }
        public string Flag { get; set; }
        public string MissionLanguage { get; set; }
        public string MissionClimate { get; set; }
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        [Key]
        public int MissionQuestionID { get; set; }
        public string Question { get; set; }
        [Display(Name = "Answer")]
        public string Ansswer { get; set; }
    }
}