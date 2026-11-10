using FluentAssertions;
using InterviewApp.Resolvers;
using InterviewApp.Strategies;
using InterviewApp.Strategies.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace InterviewApp.Tests.Resolvers
{
    public class GreetingStrategyResolverTests
    {
        private readonly GreetingStrategyResolver _resolver;
        public GreetingStrategyResolverTests()
        {
            var loggerMock = new Mock<ILogger<GreetingStrategyResolver>>();

            var defaultStrategy = new DefaultGreetingStrategy();

            var strategies = new List<ILanguageGreetingStrategy>
            {
                new EnglishGreetingStrategy(),
                new AfrikaansGreetingStrategy(),
                new ZuluGreetingStrategy(),
                defaultStrategy
            };

            _resolver = new GreetingStrategyResolver(strategies, defaultStrategy, loggerMock.Object);
        }

        [Fact]
        public void Resolve_Should_Return_English_Strategy()
        {
            var result = _resolver.Resolve("English");

            result.Should().BeOfType<EnglishGreetingStrategy>();
        }

        [Fact]
        public void Resolve_Should_Return_Afrikaans_Strategy()
        {
            var result = _resolver.Resolve("Afrikaans");

            result.Should().BeOfType<AfrikaansGreetingStrategy>();
        }

        [Fact]
        public void Resolve_Should_Return_Zulu_Strategy()
        {
            var result = _resolver.Resolve("Zulu");

            result.Should().BeOfType<ZuluGreetingStrategy>();
        }

        [Fact]
        public void Resolve_Should_Return_Default_Strategy_When_Language_Not_Supported()
        {
            var result = _resolver.Resolve("French");

            result.Should().BeOfType<DefaultGreetingStrategy>();
        }
    }
}
