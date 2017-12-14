using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    [Table("Mission")]
    public class Mission
    {
        [Key]
        public int MissionID { get; set; }
        public string MissionName { get; set; }
        public string MissionPresident { get; set; }
        public string MissionAddress { get; set; }
        public string MissionCity { get; set; }
        public string MissionCountry { get; set; }
        public string DominantReligion { get; set; }
        public string Flag { get; set; }
        public string MissionLanguage { get; set; }
        public string MissionClimate { get; set; }
    }
}