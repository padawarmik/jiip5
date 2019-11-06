using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WpfApp1.AzureSorage
{
    class StatisticsEntity : TableEntity
    { 

        public string CL_UnitFrom { get; set; }

        public string CL_ValueFrom { get; set; }

        public string CL_UnitTo { get; set; }

        public string CL_ValueTo { get; set; }

        public string CL_UnitType { get; set; }

        public DateTime? CL_Date { get; set; }

        public override string ToString()
        {
            return this.CL_ValueFrom.ToString();
        }
    }
    
}
