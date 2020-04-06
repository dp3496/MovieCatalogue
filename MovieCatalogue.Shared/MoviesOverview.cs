using System.Collections.Generic;

namespace MovieCatalogue.Shared
{
    public class MoviesOverview
    {
        public List<MovieOverview> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
