using System;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1
{

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
