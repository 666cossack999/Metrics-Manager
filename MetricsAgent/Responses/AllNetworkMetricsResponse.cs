using System;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{

    public class AllNetworkMetricsResponse
    {
        public List<NetworkMetricDto> Metrics { get; set; }
    }
    public class NetworkMetricDto
    {
        public DateTimeOffset Time { get; set; }
        public long Value { get; set; }
        public int Id { get; set; }
    }
}