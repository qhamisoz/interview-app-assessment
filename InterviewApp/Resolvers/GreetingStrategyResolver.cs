using InterviewApp.Strategies.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewApp.Resolvers;

public class GreetingStrategyResolver : IGreetingStrategyResolver
{
    private readonly IEnumerable<ILanguageGreetingStrategy> _strategies;
    private readonly ILanguageGreetingStrategy _defaultStrategy;
    private readonly ILogger<GreetingStrategyResolver> _logger;

    public GreetingStrategyResolver(
        IEnumerable<ILanguageGreetingStrategy> strategies,
        ILanguageGreetingStrategy defaultStrategy,
        ILogger<GreetingStrategyResolver> logger)
    {
        _strategies = strategies;
        _defaultStrategy = defaultStrategy;
        _logger = logger;
    }

    public ILanguageGreetingStrategy Resolve(string language)
    {
        var strategy = _strategies.FirstOrDefault(x => x.Language.Equals(language, StringComparison.OrdinalIgnoreCase));

        if (strategy != null)
        {
            return strategy;
        }

        _logger.LogWarning("Unsupported language '{Language}'. Falling back to default language.", language);

        return _defaultStrategy;
    }
}