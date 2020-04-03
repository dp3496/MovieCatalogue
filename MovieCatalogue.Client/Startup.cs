using System.Net.Http;
using MovieCatalogue.Server;
using MovieCatalogue.Server.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MovieCatalogue.ClientApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>(s =>
            {
                var client = new HttpClient(){ BaseAddress = new System.Uri("https://localhost:44340/") };
                return client;
            });
            services.AddScoped<IMovieDataService, MovieDataService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
