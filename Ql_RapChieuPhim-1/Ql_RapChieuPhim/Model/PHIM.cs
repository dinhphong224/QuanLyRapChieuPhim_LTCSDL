//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIM()
        {
            this.HOADONs = new HashSet<HOADON>();
            this.HOADONs1 = new HashSet<HOADON>();
            this.LICHCHIEUx = new HashSet<LICHCHIEU>();
        }
    
        public string MAPHIM { get; set; }
        public string TENPHIM { get; set; }
        public Nullable<int> NAMSX { get; set; }
        public string MATL { get; set; }
        public Nullable<System.DateTime> NgayKhoiChieu { get; set; }
        public string Daodien { get; set; }
        public string QuocGia { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHCHIEU> LICHCHIEUx { get; set; }
        public virtual THELOAI THELOAI { get; set; }
    }
}