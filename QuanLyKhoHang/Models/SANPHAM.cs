//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyKhoHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.DATVAO = new HashSet<DATVAO>();
            this.DONDATHANG = new HashSet<DONDATHANG>();
            this.HANGTON = new HashSet<HANGTON>();
        }
    
        public string MASP { get; set; }
        public string MA_NCCAP { get; set; }
        public string TENSP { get; set; }
        public string LOAISP { get; set; }
        public string TENTOMTAT { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
        public Nullable<System.DateTime> NGAYCAPNHAT { get; set; }
        public Nullable<System.DateTime> NGAYHETHAN { get; set; }
        public Nullable<decimal> GIACA { get; set; }
        public Nullable<byte> STATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATVAO> DATVAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANGTON> HANGTON { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
