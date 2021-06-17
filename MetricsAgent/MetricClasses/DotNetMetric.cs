using System;

namespace MetricsAgent.MetricClasses
{
    public class DotNetMetric
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}