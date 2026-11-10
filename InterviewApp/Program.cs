using InterviewApp.Features.Greeting.Commands;
using InterviewApp.Models;
using InterviewApp.Resolvers;
using InterviewApp.Services;
using InterviewApp.Strategies;
using InterviewApp.Strategies.Interfaces;
using InterviewApp.Validators;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<GreetingOptions>(context.Configuration.GetSection("Greeting"));

                services.AddTransient<IGreetingService, GreetingService>();

                services.AddTransient<ITimeGreetingService, TimeGreetingService>();

                services.AddSingleton<IGreetingStrategyResolver, GreetingStrategyResolver>();

                services.AddSingleton<ILanguageGreetingStrategy, EnglishGreetingStrategy>();

                services.AddSingleton<ILanguageGreetingStrategy, AfrikaansGreetingStrategy>();

                services.AddSingleton<ILanguageGreetingStrategy, ZuluGreetingStrategy>();

                services.AddSingleton<ILanguageGreetingStrategy, DefaultGreetingStrategy>();

                services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(GreetUserCommand).Assembly);
                });
            })
            .Build();

        var mediator = host.Services.GetRequiredService<IMediator>();

        var greetingMessage = await mediator.Send(new GreetUserCommand());

        Console.WriteLine(greetingMessage);

        await host.RunAsync();
    }
}