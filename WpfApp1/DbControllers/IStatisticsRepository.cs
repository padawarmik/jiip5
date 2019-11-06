using System.Collections.Generic;

namespace WpfApp1
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticsObject statistic);
        IEnumerable<StatisticsObject> GetStatistics();
    }
}