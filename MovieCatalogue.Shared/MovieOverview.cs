using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace MovieCatalogue.Shared
{
    public class MovieOverview
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        [BsonElement("Year")]
        public string Year { get; set; }
        [BsonElement("imdbID")]
        public string imdbID { get; set; }
        [BsonElement("Type")]
        public string Type { get; set; }
        [BsonElement("Poster")]
        public string Poster { get; set; }
    }
}
