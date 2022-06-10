//
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

    public partial class Class_Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class_Package()
        {
            this.ClassRecords = new HashSet<ClassRecord>();
        }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Pakej ID")]
        public int cp_id { get; set; }

        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Nama Pakej")]
        public string cp_name { get; set; }
        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Yuran Pakej")]
        public Nullable<double> cp_fees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRecord> ClassRecords { get; set; }
    }
}