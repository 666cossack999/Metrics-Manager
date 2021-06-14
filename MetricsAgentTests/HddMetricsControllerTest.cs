using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController controller;
        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsControllerUnitTest()
        {
            controller = new HddMetricsController(_logger);
        }

        public void GetMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            //Act
            var result = controller.GetMetrics(fromTime,toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
