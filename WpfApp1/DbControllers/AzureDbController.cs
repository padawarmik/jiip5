using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WpfApp1.AzureSorage;

namespace WpfApp1.Commons
{

    class AzureDbController : IStatisticsRepository
    {
        private CloudTable table;
        public AzureDbController()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("CONVERSIONLOG");
            this.table.CreateIfNotExists();
        }
        public void AddStatistic(StatisticsObject statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.CL_UnitFrom = statistic.CL_UnitFrom;
            entity.CL_ValueFrom = statistic.CL_ValueFrom.ToString();
            entity.CL_UnitTo = statistic.CL_UnitTo;
            entity.CL_ValueTo = statistic.CL_ValueTo.ToString();
            entity.CL_UnitType = statistic.CL_UnitType;
            entity.CL_Date = statistic.CL_Date;
            Console.WriteLine(entity.ToString());

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticsObject> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticsObject()
            {
                CL_UnitFrom = obj.CL_UnitFrom,
                CL_ValueFrom = (decimal?)decimal.Parse(obj.CL_ValueFrom),
                CL_UnitTo = obj.CL_UnitTo,
                CL_ValueTo = (decimal?)decimal.Parse(obj.CL_ValueTo),
                CL_UnitType = obj.CL_UnitType,
                CL_Date = obj.CL_Date,
            }).ToList();
        }
    }
}
