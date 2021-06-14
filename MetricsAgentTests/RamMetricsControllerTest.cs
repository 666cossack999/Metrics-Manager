using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsControllerUnitTest
    {
        private RamMetricsController controller;
        private readonly ILogger<RamMetricsController> _logger;

        public RamMetricsControllerUnitTest(ILogger<RamMetricsController> logger)
        {
            _logger = logger;
            controller = new RamMetricsController(logger);
        }

        [Fact]
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
