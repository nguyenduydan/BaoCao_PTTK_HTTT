﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.THONGTINBAOCAO = new HashSet<THONGTINBAOCAO>();
            this.THONGTINDDH = new HashSet<THONGTINDDH>();
        }
        [Required(ErrorMessage = "Không được để trống")]

        public string MASP { get; set; }
        public string MA_KEHANG { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string MA_NCCAP { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string TENSP { get; set; }
        public string LOAISP { get; set; }
        public string TENTOMTAT { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
        public Nullable<System.DateTime> NGAYCAPNHAT { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public Nullable<System.DateTime> NGAYHETHAN { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [DisplayFormat(DataFormatString = "{0:0.###}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> GIATIEN { get; set; }
        public Nullable<byte> TRANGTHAI { get; set; }

        public virtual KEHANG KEHANG { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGTINBAOCAO> THONGTINBAOCAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGTINDDH> THONGTINDDH { get; set; }
    }
}
