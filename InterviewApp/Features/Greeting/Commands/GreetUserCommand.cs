using MediatR;

namespace InterviewApp.Features.Greeting.Commands
{
    public sealed record GreetUserCommand : IRequest<string>;
}
