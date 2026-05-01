using MediatR;
using Microsoft.Extensions.Logging;
using PessoaWrite.Application.Abstractions.Messaging;
using PessoaWrite.Application.Abstractions.Persistence;

namespace PessoaWrite.Application.Features.Pessoas.CriarPessoa;

public sealed class CriarPessoaHandler(IPessoaRepository pessoaRepository, CriarPessoaCommandValidator validator, IEventPublisher publisher) : IRequestHandler<CriarPessoaCommand, Guid>
{
    private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
    private readonly CriarPessoaCommandValidator _validator = validator;
    private readonly IEventPublisher _publisher = publisher;


    public async Task<Guid> Handle(CriarPessoaCommand command, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        cancellationToken.ThrowIfCancellationRequested();

        _validator.ValidateAndThrow(command);

        var pessoa = PessoaMapper.Parse(command);

        await _pessoaRepository.AdicionarAsync(pessoa);

        Console.WriteLine($"Event dispatched at {DateTime.UtcNow}");
        await _publisher.PublishAsync(PessoaMapper.ToMessage(pessoa), cancellationToken);

        return pessoa.Id;
    }
}
