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
    
    public partial class THONGTINDDH
    {
        public string MA_DATHANG { get; set; }
        public string MASP { get; set; }
        public Nullable<int> SOLUONG { get; set; }
    
        public virtual DONDATHANG DONDATHANG { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
