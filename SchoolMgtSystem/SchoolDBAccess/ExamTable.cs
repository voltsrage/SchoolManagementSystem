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

    public partial class ExamTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamTable()
        {
            this.MarksTables = new HashSet<MarksTable>();
            this.ExamSettingTables = new HashSet<ExamSettingTable>();
        }
    
        public int ExamID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> StartDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarksTable> MarksTables { get; set; }
        public virtual UserTable UserTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamSettingTable> ExamSettingTables { get; set; }
    }
}
