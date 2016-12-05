using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MissionSite.Models;

namespace MissionSite.DAL
{
    public class MissionaryContext : DbContext
    {
        public MissionaryContext() : base("MissionaryContext")
        {

        }

        public DbSet<Missions> Mission { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<MissionQuestions> MissionQuestion { get; set; }

    }
}