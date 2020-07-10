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

    public partial class StudentTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentTable()
        {
            this.MarksTables = new HashSet<MarksTable>();
            this.SchoolLeavingTables = new HashSet<SchoolLeavingTable>();
            this.StudentAttendanceTables = new HashSet<StudentAttendanceTable>();
            this.StudentPromotionTables = new HashSet<StudentPromotionTable>();
            this.SubmissionTables = new HashSet<SubmissionTable>();
        }
    
        public int StudentID { get; set; }
        public Nullable<int> SessionID { get; set; }
        public Nullable<int> ProgramID { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string StudentIdCard { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> AdmissionDate { get; set; }
        public string PreviousSchool { get; set; }
        public Nullable<double> PreviousClassAverage { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        public string FatherPhoneNo_ { get; set; }
        public string MotherPhoneNo_ { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarksTable> MarksTables { get; set; }
        public virtual ProgramTable ProgramTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolLeavingTable> SchoolLeavingTables { get; set; }
        public virtual SessionTable SessionTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendanceTable> StudentAttendanceTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentPromotionTable> StudentPromotionTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubmissionTable> SubmissionTables { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
