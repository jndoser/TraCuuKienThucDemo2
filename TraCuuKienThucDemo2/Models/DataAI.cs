namespace TraCuuKienThucDemo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataAI")]
    public partial class DataAI
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        [StringLength(500)]
        public string Chuong { get; set; }

        [StringLength(50)]
        public string Loai { get; set; }
    }
}
