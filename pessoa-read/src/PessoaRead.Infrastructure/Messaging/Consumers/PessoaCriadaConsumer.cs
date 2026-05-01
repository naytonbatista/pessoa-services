using MassTransit;
using Microsoft.Extensions.Logging;
using Pessoa.Contracts.Pessoa;
using PessoaRead.Infrastructure.Persistence;

public class PessoaCriadaConsumer : IConsumer<PessoaCriadaMessage>
{
    private readonly ILogger<PessoaCriadaConsumer> _logger;
    private readonly PessoaReadDbContext _dbContext;

    public PessoaCriadaConsumer(ILogger<PessoaCriadaConsumer> logger, PessoaReadDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<PessoaCriadaMessage> context)
    {
        var message = context.Message;

        _logger.LogInformation("Received PessoaCriada event: {Message} at {DateTime}", message, DateTime.UtcNow);

        var pessoaReadModel = message.ToReadModel();

        _dbContext.Pessoas.Add(pessoaReadModel);
        await _dbContext.SaveChangesAsync();
    }
}
