using InterviewApp.Models;
using System;

namespace InterviewApp.Validators
{
    public static class GreetingOptionsValidator
    {
        public static void Validate(GreetingOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Message))
            {
                throw new ArgumentException("Greeting:Message is required.");
            }

            if (string.IsNullOrWhiteSpace(options.Language))
            {
                throw new ArgumentException("Greeting:Language is required.");
            }
        }
    }
}
