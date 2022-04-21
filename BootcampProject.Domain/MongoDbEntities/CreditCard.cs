using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Domain.MongoDbEntities
{
    public class CreditCard
    {
        [BsonElement("issuingNetwork")]
        public string IssuingNetwork { get; set; }
        [BsonElement("cardNumber")]
        public string CardNumber { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("balance")]
        public double Balance { get; set; }
        [BsonElement("cvv")]
        public string CVV { get; set; }
        [BsonElement("expiry")]
        public string Expiry { get; set; }
    }
}
