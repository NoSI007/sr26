//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sr26
{
    using System;
    using System.Collections.Generic;
    
    public partial class FOOD_DES
    {
        public FOOD_DES()
        {
            this.NUT_DATA = new HashSet<NUT_DATA>();
        }
    
        public int NDB_No { get; set; }
        public Nullable<short> FdGrp_Cd { get; set; }
        public string Long_Desc { get; set; }
        public Nullable<short> Refuse { get; set; }
        public Nullable<float> N_Factor { get; set; }
        public Nullable<float> Pro_Factor { get; set; }
        public Nullable<float> Fat_Factor { get; set; }
        public Nullable<float> CHO_Factor { get; set; }
    
        public virtual FD_GROUP FD_GROUP { get; set; }
        public virtual ICollection<NUT_DATA> NUT_DATA { get; set; }
    }
}
