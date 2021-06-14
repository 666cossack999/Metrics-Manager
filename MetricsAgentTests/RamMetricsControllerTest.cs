using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;


namespace MetricsAgentTests
{
    public class RamMetricsControllerUnitTest
    {
        private RamMetricsController controller;

        public RamMetricsControllerUnitTest()
        {
            controller = new RamMetricsController();
        }

        [Fact]
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
