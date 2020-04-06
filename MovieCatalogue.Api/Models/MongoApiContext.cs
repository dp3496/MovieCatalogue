using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieCatalogue.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCatalogue.Api.Models
{
    public class MongoApiContext : DbContext

    {
        private readonly IMongoDatabase _mongoDb;
        public MongoApiContext()
        {
            var client = new MongoClient("mongodb://movie-catalogue:fUGmM2bomI6DREMRuFRcABO2bRIJrqb13Vm1AlikS9V1OafynVpkDGzv4jJ6dOzwin6QiIYRC6RnkQmiMvdhlg==@movie-catalogue.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@movie-catalogue@");
            _mongoDb = client.GetDatabase("db");
        }
        public IMongoCollection<MovieOverview> Movies
        {
            get
            {
                return _mongoDb.GetCollection<MovieOverview>("MovieCollection");
            }
        }
    }
}
