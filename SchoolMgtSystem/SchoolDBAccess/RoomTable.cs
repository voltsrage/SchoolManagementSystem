//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolDBAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoomTable
    {
        public int RoomID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string RoomNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    
        public virtual UserTable UserTable { get; set; }
    }
}
