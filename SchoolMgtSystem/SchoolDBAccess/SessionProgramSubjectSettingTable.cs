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
    
    public partial class SessionProgramSubjectSettingTable
    {
        public int SessionProgramSubjectSettingID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> SessionID { get; set; }
        public Nullable<int> ProgramID { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
        public string Description { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual ProgramTable ProgramTable { get; set; }
        public virtual SessionTable SessionTable { get; set; }
        public virtual UserTable UserTable { get; set; }
        public virtual SubjectTable SubjectTable { get; set; }
    }
}
