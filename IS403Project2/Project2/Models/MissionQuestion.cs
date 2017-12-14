using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    [Table("MissionQuestion")]
    public class MissionQuestion
    {
        [Key]
        public int MissionQuestionID { get; set; }
        public int? MissionID { get; set; }
        public int? UserID { get; set; }
        public string Question { get; set; }
        public string Ansswer { get; set; }
    }
}