using InterviewApp.Strategies.Interfaces;

namespace InterviewApp.Strategies
{
    public class EnglishGreetingStrategy : ILanguageGreetingStrategy
    {
        public string Language
        {
            get 
            { 
                return "English"; 
            }
        }

        public string GetGreeting()
        {
            return "Hello";
        }
    }
}
