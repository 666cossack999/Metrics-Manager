using System;

namespace MetricsAgent.MetricClasses
{
    public class NetworkMetric
    {
        public int Id { get; set; }

        public long Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}