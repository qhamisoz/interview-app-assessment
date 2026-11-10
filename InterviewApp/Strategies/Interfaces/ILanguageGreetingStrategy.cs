namespace InterviewApp.Strategies.Interfaces
{
    public interface ILanguageGreetingStrategy
    {
        string Language { get; }
        string GetGreeting();
    }
}
