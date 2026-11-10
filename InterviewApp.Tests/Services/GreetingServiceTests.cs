using FluentAssertions;
using InterviewApp.Models;
using InterviewApp.Resolvers;
using InterviewApp.Services;
using InterviewApp.Strategies.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace InterviewApp.Tests.Services
{
    public class GreetingServiceTests
    {
        [Fact]
        public void Run_Should_Not_Throw_Exception()
        {
            // Arrange
            var options = Options.Create(
                new GreetingOptions
                {
                    Language = "English",
                    Message = "Welcome"
                });

            var loggerMock = new Mock<ILogger<GreetingService>>();

            var resolverMock = new Mock<IGreetingStrategyResolver>();

            var strategyMock = new Mock<ILanguageGreetingStrategy>();

            var timeGreetingMock = new Mock<ITimeGreetingService>();

            strategyMock.Setup(x => x.GetGreeting()).Returns("Hello");

            resolverMock.Setup(x => x.Resolve("English")).Returns(strategyMock.Object);

            timeGreetingMock.Setup(x => x.GetTimeGreeting()).Returns("Good Morning");

            var service = new GreetingService(
                options,
                loggerMock.Object,
                resolverMock.Object,
                timeGreetingMock.Object);

            // Act
            void RunGreeting()
            {
                service.Run();
            }

            Action action = RunGreeting;

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Run_Should_Log_Information()
        {
            // Arrange
            var options = Options.Create(
                new GreetingOptions
                {
                    Language = "English",
                    Message = "Welcome"
                });

            var loggerMock = new Mock<ILogger<GreetingService>>();

            var resolverMock = new Mock<IGreetingStrategyResolver>();

            var strategyMock = new Mock<ILanguageGreetingStrategy>();

            var timeGreetingMock = new Mock<ITimeGreetingService>();

            strategyMock.Setup(x => x.GetGreeting())
                .Returns("Hello");

            resolverMock.Setup(x => x.Resolve(It.IsAny<string>()))
                .Returns(strategyMock.Object);

            timeGreetingMock.Setup(x => x.GetTimeGreeting())
                .Returns("Good Morning");

            var service = new GreetingService(
                options,
                loggerMock.Object,
                resolverMock.Object,
                timeGreetingMock.Object);

            // Act
            service.Run();

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception?, string>)
                        It.IsAny<object>()),
                Times.AtLeastOnce);
        }
    }
}
