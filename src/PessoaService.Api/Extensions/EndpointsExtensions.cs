namespace pessoa_service.Extensions
{
    public static class EndpointsExtensions
    {
        public static void MapApiEndpoints(this WebApplication app)
        {
            var endpoints = app.Services.GetServices<Abstractions.IEndpoint>();

            endpoints.ToList().ForEach(endpoint => endpoint.MapEndpoints(app));

        }
    }
}
