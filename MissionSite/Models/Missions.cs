using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionSite.Models
{
    [Table("Missions")]
    public class Missions
    {
        [Key]
        public int MissionID { get; set; }
        public string MissionName { get; set; }
        public string MissionPresident { get; set; }
        public string MissionStreet1 { get; set; }
        public string MissionStreet2 { get; set; }
        public string MissionCountryCode { get; set; }
        public string MissionLanguage { get; set; }
        public string MissionClimate { get; set; }
        public string MissionReligion { get; set; }
        public string MissionFlag { get; set; }
    }
}