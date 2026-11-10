using InterviewApp.Strategies.Interfaces;

namespace InterviewApp.Strategies
{
    public sealed class AfrikaansGreetingStrategy : ILanguageGreetingStrategy
    {
        public string Language
        {
            get
            {
                return "Afrikaans";
            }
        }

        public string GetGreeting()
        {
            return "Hallo";
        }
    }
}
