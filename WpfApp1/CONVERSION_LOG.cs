namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Z502_17.CONVERSION_LOG")]
    public partial class CONVERSION_LOG
    {
        [Key]
        public long CL_ID { get; set; }

        [StringLength(10)]
        public string CL_UnitFrom { get; set; }

        public decimal? CL_ValueFrom { get; set; }

        [StringLength(10)]
        public string CL_UnitTo { get; set; }

        public decimal? CL_ValueTo { get; set; }

        [StringLength(20)]
        public string CL_UnitType { get; set; }

        public DateTime? CL_Date { get; set; }
    }
}
