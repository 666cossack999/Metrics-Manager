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
    public class RamMetricsControllerUnitTest
    {
        private RamMetricsController controller;
        private Mock<IRamMetricsRepository> repositoryMock;
        private Mock<ILogger<RamMetricsController>> _loggerMock;

        public RamMetricsControllerUnitTest()
        {
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            repositoryMock = new Mock<IRamMetricsRepository>();
            controller = new RamMetricsController(repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetMetricsByTime_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            repositoryMock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<RamMetric>());

            // выполняем действие на контроллере
            var result = controller.GetMetrics(fromTime,toTime);

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод GetByTimePeriod репозитория с нужным типом объекта в параметре
            repositoryMock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.AtLeastOnce());
            
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
