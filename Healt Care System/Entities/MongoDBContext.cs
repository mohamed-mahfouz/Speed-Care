using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Healt_Care_System.Entities
{
    public class MongoDBContext
    {
        private IMongoDatabase db;

        public MongoDBContext()
        {
            //create database if not exists
            //by deafult it connect at localhost DB.
            var host = "mongodb://localhost:27017";
            var dBName = "Hospital";
            var client = new MongoClient(host);
            db = client.GetDatabase(dBName);
        }

        
        //Insert Record Into DB.
        public void InsertRecord<T>(string table , T record)
        {

            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);

        }

        //Return List of All Records.
        public IEnumerable<T> LoadRecords<T>(string table)
        {

            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }


        

        public T LoadRecordByIdProperity<T>(string table, string id)
        {

            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);

            //return first(only one by it's id).
            return collection.Find(filter).First();
        }


        public T LoadRecordByIdProperity<T>(string table, int id)
        {

            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);

            //return first(only one by it's id).
            return collection.Find(filter).First();
        }



        //Insert or Update if Record by ObjectId _id is Exists.
        public void UPsertRecordByObjectId<T>(string table , Guid id , T record)
        {
            var collection = db.GetCollection<T>(table);

            //if the id is mathces the _id in collection records
            //then update the record
            //else make new one
            var result = collection.ReplaceOne(

                new BsonDocument("_id", id),           
                record,
                new UpdateOptions { IsUpsert = true });


        }

        //Insert or Update if Record by id is Exists.
        public void UPsertRecordByIdProperity<T>(string table, string id, T record)
        {
            var collection = db.GetCollection<T>(table);

            //if the id is mathces the _id in collection records
            //then update the record
            //else make new one
            var result = collection.ReplaceOne(

                new BsonDocument("id", id),
                record,
                new UpdateOptions { IsUpsert = true });


        }

        //delete record by object id.
        public void DeleteRecordByObjectId<T>(string table , Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }

        //delete record by id properity
        public void DeleteRecordByIdProperity<T>(string table , string id)
        {

            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);
            collection.DeleteOne(filter);
        }

    }
}