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
    
    public partial class DONTHANHTOAN
    {
        public string MATT { get; set; }
        public string MA_NCCAP { get; set; }
        public string MA_DATHANG { get; set; }
        public string LOAISP { get; set; }
        public Nullable<System.DateTime> NGAYTHANHTOAN { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<decimal> GIATIEN { get; set; }
    
        public virtual DONDATHANG DONDATHANG { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}