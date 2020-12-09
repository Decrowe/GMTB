using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.MongoDBCollections
{
    [BsonIgnoreExtraElements]
    public class DbPost
    {
        //[BsonElement("_id")]
        //public string Id { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; }
        [BsonElement("postImage")]
        public byte[] PostImage { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
     

    }
}
