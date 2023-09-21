using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Mongo.Abstractions.Document
{
    public abstract class DefinitionDocumentBase : DocumentBase
    {

        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement("modifiedOn")]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
