using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController controller;

        public HddMetricsControllerUnitTest()
        {
            controller = new HddMetricsController();
        }

        public void GetMetrics_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetMetrics();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
