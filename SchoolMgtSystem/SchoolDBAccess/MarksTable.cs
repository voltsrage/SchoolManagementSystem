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
    
    public partial class MarksTable
    {
        public int MarksID { get; set; }
        public Nullable<int> ExamID { get; set; }
        public Nullable<int> ClassSubjectID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<double> SubjectTotalMarks { get; set; }
        public Nullable<double> SubjectMarksAttained { get; set; }
    
        public virtual ClassSubjectTable ClassSubjectTable { get; set; }
        public virtual ExamTable ExamTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}