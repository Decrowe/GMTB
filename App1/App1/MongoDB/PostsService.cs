using System;
using System.Collections.Generic;
using System.Text;
using App1.MongoDBCollections;
using MongoDB;
using MongoDB.Driver;

namespace App1.MongoDB
{
    class PostsService
    {
        private readonly IMongoCollection<DbPost> _posts;
        public PostsService()
        {
            MongoHelper helper = new MongoHelper();
            _posts = helper.GetMongoDbPostCollection();
        }

        public List<DbPost> GetPostsByUserId(string userId)
        {
            var result = _posts.Find(p => p.UserId == userId).ToList();
            return result;
        }

        //public DbPost GetPostById(string id)
        //{
        //    var result = _posts.Find(p => p.Id == id).FirstOrDefault();
        //    return result;
        //}

        public DbPost Create(DbPost post)
        {
            _posts.InsertOne(post);
            return post;
        }
    }
}
