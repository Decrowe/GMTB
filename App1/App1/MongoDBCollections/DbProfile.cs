using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.MongoDBCollections
{
    [BsonIgnoreExtraElements]
    public class DbProfile
    {

        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("userName")]
        public string UserName { get; set; }
        [BsonElement("pwd")]
        public string Pwd { get; set; }
        [BsonElement("age")]
        public string Age { get; set; }
    }
}
