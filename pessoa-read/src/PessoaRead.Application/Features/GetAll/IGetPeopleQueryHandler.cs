namespace PessoaRead.Application.Features.GetAll;

public interface IGetPeopleQueryHandler
{
    Task<IEnumerable<PessoaResponse>> Handle(GetPeopleQuery query, CancellationToken cancellationToken);
}