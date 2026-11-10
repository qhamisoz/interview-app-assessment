using FluentAssertions;
using InterviewApp.Features.Greeting.Handlers;
using InterviewApp.Features.Greeting.Queries;
using InterviewApp.Services;
using Moq;

namespace InterviewApp.Tests.Handlers
{
    public class GetTimeGreetingQueryHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Return_Time_Greeting()
        {
            // Arrange
            var serviceMock = new Mock<ITimeGreetingService>();

            serviceMock.Setup(x => x.GetTimeGreeting())
                .Returns("Good Morning");

            var handler = new GetTimeGreetingQueryHandler(serviceMock.Object);

            // Act
            var result = await handler.Handle(new GetTimeGreetingQuery(), CancellationToken.None);

            // Assert
            result.Should().Be("Good Morning");
        }
    }
}
