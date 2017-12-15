using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project2.Models;
using System.Data.Entity;

namespace Project2.DAL
{
    public class AzureContext : DbContext
    {
        public AzureContext() : base("AzureContext")
        {

        }
        //getters and setters for the objects of each class below
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionQuestion> MissionQuestions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMissionQuestion> UserMissionQuestions { get; set; }
    }

 
}