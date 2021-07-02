using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.MetricClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController controller;
        private Mock<IDotNetMetricsRepository> repositoryMock;
        private Mock<ILogger<DotNetMetricsController>> _loggerMock;

        public DotNetMetricsControllerUnitTest()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            repositoryMock = new Mock<IDotNetMetricsRepository>();
            controller = new DotNetMetricsController(repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит DotNetMetric объект
            repositoryMock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<DotNetMetric>());

            // выполняем действие на контроллере
            var result = controller.GetMetrics(fromTime, toTime);

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод GetByTimePeriod репозитория с нужным типом объекта в параметре
            repositoryMock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.AtLeastOnce());
            
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
