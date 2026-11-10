using FluentAssertions;
using InterviewApp.Services;

namespace InterviewApp.Tests.Services
{
    public class TimeGreetingServiceTests
    {
        [Fact]
        public void GetTimeGreeting_Should_Return_Valid_Greeting()
        {
            // Arrange
            var service = new TimeGreetingService();

            // Act
            var result = service.GetTimeGreeting();

            // Assert
            result.Should().BeOneOf(
                    "Good Morning",
                    "Good Afternoon",
                    "Good Evening"
                );
        }
    }
}
