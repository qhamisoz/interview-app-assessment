using InterviewApp.Strategies.Interfaces;

namespace InterviewApp.Strategies
{
    public sealed class ZuluGreetingStrategy : ILanguageGreetingStrategy
    {
        public string Language
        {
            get
            {
                return "Zulu";
            }
        }

        public string GetGreeting()
        {
            return "Sawubona";
        }
    }
}
