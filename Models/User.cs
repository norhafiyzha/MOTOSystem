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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.ClassRecords = new HashSet<ClassRecord>();
            this.PerformanceReports = new HashSet<PerformanceReport>();
            this.SalaryInvoices = new HashSet<SalaryInvoice>();
        }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("ID Pengguna")]
        public string u_id { get; set; }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DataType(DataType.Password)]
        [StringLength(150, ErrorMessage = "{0} hendaklah sekurang-kurangnya {2} karakter", MinimumLength = 5)]
        [Display(Name = "Kata Laluan")]
        public string u_password { get; set; }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string u_email { get; set; }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Nama Pertama")]
        public string u_fname { get; set; }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Nama Akhir")]
        public string u_lname { get; set; }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Jawatan")]
        public string u_roles { get; set; }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("No Telefon")]
        public string u_contact { get; set; }
        public string u_passcode { get; set; }

        public string LoginErrorMessage { get; set; }
        public bool RememberMe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRecord> ClassRecords { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceReport> PerformanceReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryInvoice> SalaryInvoices { get; set; }
    }
}
