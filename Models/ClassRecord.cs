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

    public partial class ClassRecord
    {
        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("ID Kelas")]
        [StringLength(10, ErrorMessage = "{0} hendaklah sekurang-kurangnya {2} karakter", MinimumLength = 3)]
        public string class_id { get; set; }
        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("ID Pengguna")]
        public string u_id { get; set; }
        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Durasi Kelas")]
        public string class_time { get; set; }
        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Pengajar")]
        public string class_teacher { get; set; }
        [Required(ErrorMessage = "Ruangan ini perlu dipenuhi")]
        [DisplayName("Pakej Kelas")]
        public Nullable<int> class_package { get; set; }
    
        public virtual Class_Package Class_Package1 { get; set; }
        public virtual User User { get; set; }
    }
}
