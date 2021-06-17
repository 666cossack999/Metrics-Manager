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
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController controller;
        private Mock<IHddMetricsRepository> repositoryMock;
        private Mock<ILogger<HddMetricsController>> _loggerMock;

        public HddMetricsControllerUnitTest()
        {
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            repositoryMock = new Mock<IHddMetricsRepository>();
            controller = new HddMetricsController(repositoryMock.Object, _loggerMock.Object);
        }

        public void GetMetrics_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит HddMetric объект
            repositoryMock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<HddMetric>());

            // выполняем действие на контроллере
            var result = controller.GetMetrics(fromTime,toTime);

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод GetByTimePeriod репозитория с нужным типом объекта в параметре
            repositoryMock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.AtLeastOnce());
            
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
