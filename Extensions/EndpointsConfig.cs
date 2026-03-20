using pessoa_service.Features.Pessoas;
using pessoa_service.Features.Contatos;

namespace pessoa_service.Extensions
{
    public static class EndpointsConfig
    {
        public static void MapApiEndpoints(this WebApplication app)
        {
            var endpoints = app.Services.GetServices<Abstractions.IEndpoint>();

            endpoints.ToList().ForEach(endpoint => endpoint.MapEndpoints(app));

        }
    }
}
