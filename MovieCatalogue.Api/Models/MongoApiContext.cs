using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieCatalogue.Shared;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace MovieCatalogue.Api.Models
{
    public class MongoApiContext : DbContext
    {
        private string userName = "movie-catalogue";
        private string host = "movie-catalogue.mongo.cosmos.azure.com";
        private string password = "fUGmM2bomI6DREMRuFRcABO2bRIJrqb13Vm1AlikS9V1OafynVpkDGzv4jJ6dOzwin6QiIYRC6RnkQmiMvdhlg==";

        // This sample uses a database named "Tasks" and a 
        //collection named "TasksList".  The database and collection 
        //will be automatically created if they don't already exist.
        private string dbName = "db";
        private string collectionName = "MovieCollection";


        private readonly IMongoDatabase _mongoDb;
        public MongoApiContext()
        {
            //var client = new MongoClient("mongodb://movie-catalogue:fUGmM2bomI6DREMRuFRcABO2bRIJrqb13Vm1AlikS9V1OafynVpkDGzv4jJ6dOzwin6QiIYRC6RnkQmiMvdhlg==@movie-catalogue.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@movie-catalogue@");
            //_mongoDb = client.GetDatabase("db");






            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, 10255);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);
            settings.RetryWrites = false;

            MongoClient client = new MongoClient(settings);
            _mongoDb = client.GetDatabase(dbName);
        }
        public IMongoCollection<MovieOverview> Movies
        {
            get
            {
                return _mongoDb.GetCollection<MovieOverview>(collectionName);
                //List<MovieOverview> list = todoTaskCollection.Find(new BsonDocument()).ToList();
                //return list;
            }
        }
    }
}
