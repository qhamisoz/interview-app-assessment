using InterviewApp.Strategies.Interfaces;

namespace InterviewApp.Strategies
{
    public sealed class DefaultGreetingStrategy : ILanguageGreetingStrategy
    {
        public string Language
        {
            get
            {
                return "Default";
            }
        }

        public string GetGreeting()
        {
            return "Hello";
        }
    }
}