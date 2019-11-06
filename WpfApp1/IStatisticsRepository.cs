using System.Collections.Generic;
using WpfApp1.Commons;

namespace WpfApp1
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticsObject statistic);
        IEnumerable<StatisticsObject> GetStatistics();
    }
}