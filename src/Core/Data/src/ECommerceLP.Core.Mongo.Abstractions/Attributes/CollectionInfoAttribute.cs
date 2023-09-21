using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Mongo.Abstractions.Attributes
{
    public class CollectionInfoAttribute : System.Attribute
    {
        /// <value>Name of the collection</value>
        public string CollectionName { get; set; }
    }
}
