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

    public partial class MarksTable
    {
        [Key]
        [Display(Name = "Marks ID")]
        public int MarksID { get; set; }
        [Display(Name = "Exam ID")]
        public Nullable<int> ExamID { get; set; }
        [Display(Name = "Class Subject ID")]
        public Nullable<int> ClassSubjectID { get; set; }
        [Display(Name = "Student ID")]
        public Nullable<int> StudentID { get; set; }
        [Display(Name = "User ID")]
        public Nullable<int> UserID { get; set; }
        [Display(Name = "Subject Total Marks")]
        public Nullable<double> SubjectTotalMarks { get; set; }
        [Display(Name = "Subject Marks Attained")]
        public Nullable<double> SubjectMarksAttained { get; set; }

        public virtual ClassSubjectTable ClassSubjectTable { get; set; }
        public virtual ExamTable ExamTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
