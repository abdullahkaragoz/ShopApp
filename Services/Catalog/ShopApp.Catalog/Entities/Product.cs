﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShopApp.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProcutID { get; set; }
        public string ProcutName { get; set; }
        public decimal ProcutPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}