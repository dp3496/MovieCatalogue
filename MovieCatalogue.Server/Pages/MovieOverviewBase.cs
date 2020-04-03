using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieCatalogue.Server.Services;
using MovieCatalogue.Shared;
using Microsoft.AspNetCore.Components;

namespace MovieCatalogue.Server.Pages
{
    public class MovieOverviewBase : ComponentBase
    {
        [Inject]
        public IMovieDataService EmployeeDataService { get; set; }

        public List<Search> Movies { get; set; }

        public string SearchString  { get; set;}

        public async void DisplayMovies()
        {
            Movies = (await EmployeeDataService.GetAllMovies(SearchString)).Search;
            StateHasChanged();
        }

        protected void OnSearchClick()
        {
            DisplayMovies();
        }

        public async void UpdateMovieColletion() => await EmployeeDataService.AddMovie(SelectedSearch);

        protected void AddToMovieCollection()
        {
            UpdateMovieColletion();
        }

        public Search SelectedSearch { get; set; }

        protected void ClickedRow(Search s)
        {
            SelectedSearch = s;
        }
    }
}
