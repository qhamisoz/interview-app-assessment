using MediatR;

namespace InterviewApp.Features.Greeting.Queries
{
    public sealed record GetTimeGreetingQuery : IRequest<string>;
}
