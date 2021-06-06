using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using MetricsManager;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTest
    {
        private AgentsController controller;
        private AgentsInfo info;
        
        public AgentsControllerUnitTest()
        {
            controller = new AgentsController();
            info = new AgentsInfo();
        }

        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            //Arrange
            var agentInfo = info;

            //Act
            var result = controller.RegisterAgent(agentInfo);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Read_ReturnsOk()
        {
            //Arrange
            var agentInfo = info;

            //Act
            var result = controller.Read();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 32;
            var agentInfo = info;

            //Act
            var result = controller.EnableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 32;
            var agentInfo = info;

            //Act
            var result = controller.EnableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
