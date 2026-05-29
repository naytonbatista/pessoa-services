namespace PessoaRead.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapApiEndpoints(this WebApplication app)
        {
            var endpoints = app.Services.GetServices<Abstractions.IEndpoint>();

            endpoints.ToList().ForEach(endpoint => endpoint.MapEndpoints(app));

        }
    }
}