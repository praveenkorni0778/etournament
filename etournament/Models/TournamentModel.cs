using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etournament.Models
{
    public class TournamentModel
    {
        public int t_id { get; set; }
        public string t_name { get; set; }
        public string t_website { get; set; }
        public DateTime t_dts { get; set; }
        public DateTime t_dte { get; set; }
        public string t_image { get; set; }
        public int t_fk { get; set; }
        public int t_cat { get; set; }
        public string t_contact { get; set; }
        public string t_desc { get; set; }
        public string t_location { get; set; }
        public string t_entryfee { get; set; }
        public string t_prize { get; set; }
    }
}