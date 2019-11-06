using System;

namespace WpfApp1
{

    public partial class StatisticsObject
    {
        public int Id { get; set; }

        public string CL_UnitFrom { get; set; }

        public decimal? CL_ValueFrom { get; set; }

        public string CL_UnitTo { get; set; }

        public decimal? CL_ValueTo { get; set; }

        public string CL_UnitType { get; set; }

        public DateTime? CL_Date { get; set; }
    }
}
