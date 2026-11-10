using InterviewApp.Strategies.Interfaces;

namespace InterviewApp.Resolvers
{
    public interface IGreetingStrategyResolver
    {
        ILanguageGreetingStrategy Resolve(string language);
    }
}
