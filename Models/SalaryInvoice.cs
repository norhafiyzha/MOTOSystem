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

    public partial class SalaryInvoice
    {
        [Required]
        [DisplayName("ID Pengguna")]
        public int i_id { get; set; }
        [Required]
        [DisplayName("ID Pengguna")]
        public Nullable<double> i_amount { get; set; }
        [Required]
        [DisplayName("ID Pengguna")]
        public string i_status { get; set; }
        [Required]
        [DisplayName("ID Pengguna")]
        public string u_id { get; set; }
        [Required]
        [DisplayName("ID Pengguna")]
        public Nullable<int> i_month { get; set; }
    
        public virtual User User { get; set; }
    }
}
