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
    using System.ComponentModel.DataAnnotations;

    public partial class ExamSettingTable
    {
        [Key]
        [Display(Name = "Exam Setting ID")]
        public int ExamSettingID { get; set; }
        [Display(Name = "User ID")]
        public Nullable<int> UserID { get; set; }
        [Display(Name = "Session ID")]
        public Nullable<int> SessionID { get; set; }
        [Display(Name = "Exam ID")]
        public Nullable<int> ExamID { get; set; }
        [Display(Name = "Program Session ID")]
        public Nullable<int> ProgramSessionID { get; set; }
        public string Description { get; set; }

        public virtual ExamTable ExamTable { get; set; }
        public virtual ProgramSession ProgramSession { get; set; }
        public virtual SessionTable SessionTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
