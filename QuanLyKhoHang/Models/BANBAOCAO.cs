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
    
    public partial class BANBAOCAO
    {
        public string MA_BAOCAO { get; set; }
        public string MASP { get; set; }
        public string MA_HANGTON { get; set; }
        public Nullable<decimal> SOLUONG { get; set; }
        public Nullable<System.DateTime> NGAYBAOCAO { get; set; }
    
        public virtual HANGTON HANGTON { get; set; }
    }
}
