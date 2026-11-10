using InterviewApp.Models;
using InterviewApp.Resolvers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace InterviewApp.Services
{
    public class GreetingService(
        IOptions<GreetingOptions> options,
        ILogger<GreetingService> logger,
        IGreetingStrategyResolver resolver,
        ITimeGreetingService timeGreetingService) : IGreetingService
    {
        private readonly GreetingOptions _options = options.Value;

        public void Run()
        {
            logger.LogInformation("Greeting service started.");

            var strategy = resolver.Resolve(_options.Language);

            var languageGreeting = strategy.GetGreeting();

            var timeGreeting = timeGreetingService.GetTimeGreeting();

            var message = $"{languageGreeting} - {timeGreeting} - {_options.Message}";

            logger.LogInformation("Greeting displayed: {Message}", message);

            Console.WriteLine(message);
        }
    }
}