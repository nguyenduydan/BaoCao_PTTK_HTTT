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
    
    public partial class DATVAO
    {
        public string MASP { get; set; }
        public string MA_KEHANG { get; set; }
        public Nullable<int> SOLUONG { get; set; }
    
        public virtual SANPHAM SANPHAM { get; set; }
        public virtual KEHANG KEHANG { get; set; }
    }
}
