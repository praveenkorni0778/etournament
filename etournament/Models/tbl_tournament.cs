//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace etournament.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_tournament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_tournament()
        {
            this.tbl_user1 = new HashSet<tbl_user>();
        }
    
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
    
        public virtual tbl_category tbl_category { get; set; }
        public virtual tbl_user tbl_user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_user> tbl_user1 { get; set; }
    }
}
