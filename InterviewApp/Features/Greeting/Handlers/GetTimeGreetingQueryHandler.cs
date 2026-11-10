using InterviewApp.Features.Greeting.Queries;
using InterviewApp.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewApp.Features.Greeting.Handlers
{
    public sealed class GetTimeGreetingQueryHandler : IRequestHandler<GetTimeGreetingQuery, string>
    {
        private readonly ITimeGreetingService _timeGreetingService;

        public GetTimeGreetingQueryHandler(ITimeGreetingService timeGreetingService)
        {
            _timeGreetingService = timeGreetingService;
        }
        public Task<string> Handle(GetTimeGreetingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_timeGreetingService.GetTimeGreeting());
        }
    }
}
