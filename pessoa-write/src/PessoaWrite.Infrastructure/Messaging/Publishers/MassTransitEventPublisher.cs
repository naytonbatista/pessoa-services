using MassTransit;
using PessoaWrite.Application.Abstractions.Messaging;

namespace PessoaWrite.Infrastructure.Messaging.Publishers;

public sealed class MassTransitEventPublisher(IPublishEndpoint publishEndpoint) : IEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class
    {
        return _publishEndpoint.Publish(@event, cancellationToken);
    }
}
