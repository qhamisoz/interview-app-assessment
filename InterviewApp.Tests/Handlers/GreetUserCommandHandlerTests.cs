using FluentAssertions;
using InterviewApp.Features.Greeting.Commands;
using InterviewApp.Features.Greeting.Queries;
using InterviewApp.Features.Handlers;
using InterviewApp.Models;
using InterviewApp.Resolvers;
using InterviewApp.Strategies.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
using Moq;

namespace InterviewApp.Tests.Handlers
{
    public class GreetUserCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Return_Combined_Greeting_Message()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(x => x.Send(It.IsAny<GetTimeGreetingQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("Good Morning");

            var resolverMock = new Mock<IGreetingStrategyResolver>();

            var strategyMock = new Mock<ILanguageGreetingStrategy>();

            strategyMock.Setup(x => x.GetGreeting())
                .Returns("Hello");

            resolverMock.Setup(x => x.Resolve("English"))
                .Returns(strategyMock.Object);

            var options = Options.Create(
                new GreetingOptions
                {
                    Language = "English",
                    Message = "Welcome to the interview app!"
                });

            var handler = new GreetUserCommandHandler(
                    mediatorMock.Object,
                    options,
                    resolverMock.Object);

            // Act
            var result = await handler.Handle(new GreetUserCommand(), CancellationToken.None);

            // Assert
            result.Should().Be("Hello - Good Morning - Welcome to the interview app!");
        }

        [Fact]
        public async Task Handle_Should_Invoke_TimeGreeting_Query()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(x => x.Send(It.IsAny<GetTimeGreetingQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("Good Morning");

            var resolverMock = new Mock<IGreetingStrategyResolver>();

            var strategyMock = new Mock<ILanguageGreetingStrategy>();

            strategyMock.Setup(x => x.GetGreeting())
                .Returns("Hello");

            resolverMock.Setup(x => x.Resolve(It.IsAny<string>()))
                .Returns(strategyMock.Object);

            var options = Options.Create(
                new GreetingOptions
                {
                    Language = "English",
                    Message = "Welcome"
                });

            var handler = new GreetUserCommandHandler(
                    mediatorMock.Object,
                    options,
                    resolverMock.Object);

            // Act
            await handler.Handle(new GreetUserCommand(), CancellationToken.None);

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<GetTimeGreetingQuery>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
