using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
    public class StatisticsSqlRepository: IStatisticsRepository
    {
        public void AddStatistic(StatisticsObject statistic)
        {
            using (WwsiModel context = new WwsiModel())
            {
                context.CONVERSION_LOG.Add(new CONVERSION_LOG()
                {
                    CL_Date = statistic.CL_Date,
                    CL_UnitType = statistic.CL_UnitType,
                    CL_UnitFrom = statistic.CL_UnitFrom,
                    CL_UnitTo = statistic.CL_UnitTo,
                    CL_ValueFrom = statistic.CL_ValueFrom,
                    CL_ValueTo = statistic.CL_ValueTo,
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticsObject> GetStatistics()
        {
            using (WwsiModel context = new WwsiModel())
            {
                return context.CONVERSION_LOG.Select(obj => new StatisticsObject() {
                        CL_Date = obj.CL_Date,
                        CL_UnitType = obj.CL_UnitType,
                        CL_UnitFrom = obj.CL_UnitFrom,
                        CL_UnitTo = obj.CL_UnitTo,
                        CL_ValueFrom = obj.CL_ValueFrom,
                        CL_ValueTo = obj.CL_ValueTo,
                    }).ToList();
            }
        }
    }
}
