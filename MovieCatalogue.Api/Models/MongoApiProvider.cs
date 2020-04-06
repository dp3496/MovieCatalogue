using MongoDB.Driver;
using MovieCatalogue.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalogue.Api.Models
{
    public class MongoApiProvider : IMovieRepository
    {
        MongoApiContext db = new MongoApiContext();
        public async Task AddMovieAsync(MovieOverview movieOverview)
        {
            try
            {
                await db.Movies.InsertOneAsync(movieOverview);
            }
            catch
            {
                throw;
            }
        }
        public async Task<MovieOverview> GetMovieById(string title)
        {
            try
            {
                FilterDefinition<MovieOverview> filter = Builders<MovieOverview>.Filter.Eq("Title", title);
                return await db.Movies.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<MovieOverview>> GetMoviesOverView()
        {
            try
            {
                return await db.Movies.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        //public async Task Update(MovieOverview movieOverview)
        //{
        //    try
        //    {
        //        await db.Movies.ReplaceOneAsync(filter: g => g.Title == movieOverview.Title, replacement: movieOverview);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        public async Task DeleteMovie(string title)
        {
            try
            {
                FilterDefinition<MovieOverview> data = Builders<MovieOverview>.Filter.Eq("Title", title);
                await db.Movies.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }
    }
}
