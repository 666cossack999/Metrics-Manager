using System;

namespace MetricsAgent.MetricClasses
{
    public class RamMetric
    {
        public int Id { get; set; }

        public long Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}