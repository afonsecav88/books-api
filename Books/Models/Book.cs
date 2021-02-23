using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string bid { get; set; }

        public string authors { get; set; }

        public bool available { get; set; }

        public string excerpt { get; set; }

        public string frontimageurl { get; set; }

        public bool is_isbn10 { get; set; }

        public bool is_isbn13 { get; set; }

        public string isbn10 { get; set; }

        public string isbn13 { get; set; }

        public string isbnseller { get; set; }

        public int price { get; set; }

        public string pricecurrency { get; set; }

        public string publisher { get; set; }

        public int quality { get; set; }

        public string scrapdatetime { get; set; }

        public int scraptimestamp { get; set; }       
       

        public string sellerid { get; set; }

        public string sellername { get; set; }

        public string sellerurl { get; set; }

        public string spider { get; set; }

        public string stock { get; set; }

        public string title { get; set; }

        public string [] genres { get; set; }
        


    }
       
}

