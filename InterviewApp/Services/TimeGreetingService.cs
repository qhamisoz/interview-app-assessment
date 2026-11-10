using System;

namespace InterviewApp.Services
{
    public sealed class TimeGreetingService : ITimeGreetingService
    {
        public string GetTimeGreeting()
        {
            int hour = DateTime.Now.Hour;

            if (hour < 12)
            {
                return "Good Morning";
            }

            if (hour < 18)
            {
                return "Good Afternoon";
            }

            return "Good Evening";
        }
    }
}
