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
    
    public partial class EmployeeLanguageTable
    {
        public int EmployeeLanguageID { get; set; }
        public string LanguageName { get; set; }
        public string Proficiency { get; set; }
        public Nullable<int> EmployeeResumeID { get; set; }
        public int UserID { get; set; }
    
        public virtual EmployeeResumeTable EmployeeResumeTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
