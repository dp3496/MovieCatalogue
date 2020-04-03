using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCatalogue.Server.Services;
using MovieCatalogue.Shared;
using Microsoft.AspNetCore.Components;

namespace MovieCatalogue.Server.Pages
{
    public class MovieDetailBase : ComponentBase
    {
        [Inject]
        public IMovieDataService EmployeeDataService { get; set; }

        [Parameter]
        public string Title { get; set; }
       
        public Movie Movie { get; set; } = new Movie();

        protected override async Task OnInitializedAsync()
        {
            Movie = await EmployeeDataService.GetMovieDetails(Title);
        }
    }
}
