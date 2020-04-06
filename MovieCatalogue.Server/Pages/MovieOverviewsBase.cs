using System.Collections.Generic;
using MovieCatalogue.Server.Services;
using Microsoft.AspNetCore.Components;
using MovieCatalogue.Shared;

namespace MovieCatalogue.Server.Pages
{
    public class MovieOverviewsBase : ComponentBase
    {
        [Inject]
        public IMovieDataService EmployeeDataService { get; set; }

        public List<MovieCatalogue.Shared.MovieOverview> Movies { get; set; }

        public string SearchString  { get; set;}

        public async void DisplayMovies()
        {
            Movies = (await EmployeeDataService.GetAllMatchingMovies(SearchString)).Search;
            StateHasChanged();
        }

        protected void OnSearchClick()
        {
            DisplayMovies();
        }

        //public async void UpdateMovieColletion() => await EmployeeDataService.AddMovie(SelectedSearch);
        //public async void UpdateMovieColletion()
        //{
        //    await EmployeeDataService.AddMovie(SelectedSearch);
        //}

        //protected void AddToMovieCollection()
        //{
        //    UpdateMovieColletion();
        //}

        public MovieCatalogue.Shared.MovieOverview SelectedSearch { get; set; }

        protected void ClickedRow(MovieCatalogue.Shared.MovieOverview s)
        {
            SelectedSearch = s;
        }
    }
}
