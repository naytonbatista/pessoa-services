using PessoaRead.Application.Abstractions.Repository;

namespace PessoaRead.Application.Features.GetAll;

public sealed class GetPeopleQueryHandler : IGetPeopleQueryHandler
{
    private readonly IPessoaRepository _context;

    public GetPeopleQueryHandler(IPessoaRepository context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PessoaResponse>> Handle(GetPeopleQuery query, CancellationToken cancellationToken)
    {

        var pessoas = await _context.GetAllAsync(cancellationToken);

        return pessoas.AsEnumerable();
    }
}