//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MOTOSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.ClassRecords = new HashSet<ClassRecord>();
            this.PerformanceReports = new HashSet<PerformanceReport>();
            this.SalaryInvoices = new HashSet<SalaryInvoice>();
        }
    
        public string u_id { get; set; }
        public string u_password { get; set; }
        public string u_email { get; set; }
        public string u_fname { get; set; }
        public string u_lname { get; set; }
        public string u_roles { get; set; }
        public string u_contact { get; set; }
        public string u_passcode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRecord> ClassRecords { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceReport> PerformanceReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryInvoice> SalaryInvoices { get; set; }
    }
}
