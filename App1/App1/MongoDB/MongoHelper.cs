using App1.MongoDBCollections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;



namespace App1.MongoDB
{
    public class MongoHelper
{
        // public MongoCollection<BsonDocument> Collection { get; private set; }
        
        public  MongoHelper()
        {
            var client = new MongoClient("mongodb+srv://AppUser1:appuser1@gmtb.nxwzp.mongodb.net/sample_analytics?retryWrites=true&w=majority");
            var database = client.GetDatabase("gmtb");
            var collectionProfiles = database.GetCollection<DbProfile>("profiles");

            var users = collectionProfiles.Find(u => u.Age == "21").ToList();
            foreach (var user in users)
            {
                Console.WriteLine(user.Id);
            }
            
            //var documnt = new profiles
            //{
            //    {"name","Kevlon" },
            //    {"Age","21"},
            //    {"Bike","Müsing" },
            //};

            //col.InsertOneAsync(documnt); 
        }
   
        //Methods which return the corresponding collection
        public IMongoCollection<DbProfile> GetMongoDbProfileCollection()
        {
            var client = new MongoClient("mongodb+srv://AppUser1:appuser1@gmtb.nxwzp.mongodb.net/sample_analytics?retryWrites=true&w=majority");
            var database = client.GetDatabase("gmtb");
            IMongoCollection<DbProfile> collectionProfiles = database.GetCollection<DbProfile>("profiles");
            return collectionProfiles;
        }
        public IMongoCollection<DbPost> GetMongoDbPostCollection()
        {
            var client = new MongoClient("mongodb+srv://CoAdmin1:J1OCmTDi3MPhQSOMOw6o@gmtb.nxwzp.mongodb.net/sample_analytics?retryWrites=true&w=majority");
            var database = client.GetDatabase("gmtb");
            IMongoCollection<DbPost> collectionPosts = database.GetCollection<DbPost>("posts");
            return collectionPosts;
        }
        public IMongoCollection<DbFriend> GetMongoDbFriendCollection()
        {
            var client = new MongoClient("mongodb+srv://AppUser1:appuser1@gmtb.nxwzp.mongodb.net/sample_analytics?retryWrites=true&w=majority");
            var database = client.GetDatabase("gmtb");
            IMongoCollection<DbFriend> collectionFriends = database.GetCollection<DbFriend>("friends");
            return collectionFriends;
        }

    }
}
