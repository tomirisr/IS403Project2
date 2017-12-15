using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    //pulling data from the mission table
    [Table("Mission")]
    public class Mission
    {
        [Key]
        public int MissionID { get; set; }
        [Display(Name = "Mission Name")]
        public string MissionName { get; set; }
        [Display(Name = "Mission President")]
        public string MissionPresident { get; set; }
        [Display(Name = "Address")]
        public string MissionAddress { get; set; }
        [Display(Name = "City")]
        public string MissionCity { get; set; }
        [Display(Name = "Country")]
        public string MissionCountry { get; set; }
        [Display(Name = "Dominant Religion")]
        public string DominantReligion { get; set; }
        public string Flag { get; set; }
        [Display(Name = "Mission Language")]
        public string MissionLanguage { get; set; }
        [Display(Name = "Climate")]
        public string MissionClimate { get; set; }
    }
}