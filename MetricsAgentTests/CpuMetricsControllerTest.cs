using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.MetricClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using AutoMapper;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTest
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> repositoryMock;
        private Mock<ILogger<CpuMetricsController>> _loggerMock;
        private Mock<IMapper> _mapper;

        public CpuMetricsControllerUnitTest()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            repositoryMock = new Mock<ICpuMetricsRepository>();
            _mapper = new Mock<IMapper>();
            controller = new CpuMetricsController(repositoryMock.Object, _loggerMock.Object, _mapper.Object);
        }

        [Fact]
        public void GetMetricsByTime_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            repositoryMock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<CpuMetric>());

            // ��������� �������� �� �����������
            var result = controller.GetMetricsByTime(fromTime, toTime);

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� GetByTimePeriod ����������� � ������ ����� ������� � ���������
            repositoryMock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.AtLeastOnce());

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
