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
    
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            this.DONTHANHTOAN = new HashSet<DONTHANHTOAN>();
        }
    
        public string MASP { get; set; }
        public string MA_DATHANG { get; set; }
        public string TEN_SP { get; set; }
        public string MA_NCCAP { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<System.DateTime> NGAY_DATHANG { get; set; }
    
        public virtual SANPHAM SANPHAM { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONTHANHTOAN> DONTHANHTOAN { get; set; }
    }
}
