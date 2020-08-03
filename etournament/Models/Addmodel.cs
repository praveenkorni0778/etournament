using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etournament.Models
{
    public class Addmodel
    {
        public int t_id { get; set; }
        public string t_name { get; set; }
        public string t_add { get; set; }
        public string t_website { get; set; }
        public System.DateTime t_dts { get; set; }
        public System.DateTime t_dte { get; set; }
        public string t_contact { get; set; }
        public string t_image { get; set; }
        public Nullable<int> t_cat { get; set; }
        public Nullable<int> t_fk { get; set; }
        public string t_desc { get; set; }
        public string t_location { get; set; }
        public string t_entryfee { get; set; }
        public string t_prize { get; set; }
        public string u_img { get; set; }
        public int u_id { get; set; }
        public string u_name { get; set; }
        public string u_email { get; set; }
        public string u_password { get; set; }
        public int u_age { get; set; }
        public System.DateTime u_dob { get; set; }
        public string u_contact { get; set; }
        public string u_gender { get; set; }
        public string u_desc { get; set; }
        public int c_id { get; set; }
        public string c_name { get; set; }
        public string c_img { get; set; }
        public Nullable<int> c_ref { get; set; }
        public int c_status { get; set; }

    }
}