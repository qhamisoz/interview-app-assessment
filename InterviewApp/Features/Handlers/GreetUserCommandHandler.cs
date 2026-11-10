using InterviewApp.Features.Greeting.Commands;
using InterviewApp.Features.Greeting.Queries;
using InterviewApp.Models;
using InterviewApp.Resolvers;
using InterviewApp.Services;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewApp.Features.Handlers
{
    public sealed class GreetUserCommandHandler
    : IRequestHandler<GreetUserCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly GreetingOptions _options;
        private readonly IGreetingStrategyResolver _resolver;

        public GreetUserCommandHandler(IMediator mediator, IOptions<GreetingOptions> options, IGreetingStrategyResolver resolver)
        {
            _mediator = mediator;
            _options = options.Value;
            _resolver = resolver;
        }

        public async Task<string> Handle(GreetUserCommand request, CancellationToken cancellationToken)
        {
            var strategy = _resolver.Resolve(_options.Language);

            var languageGreeting = strategy.GetGreeting();

            var timeGreeting = await _mediator.Send(new GetTimeGreetingQuery(), cancellationToken);

            return $"{languageGreeting} - {timeGreeting} - {_options.Message}";
        }
    }
}
