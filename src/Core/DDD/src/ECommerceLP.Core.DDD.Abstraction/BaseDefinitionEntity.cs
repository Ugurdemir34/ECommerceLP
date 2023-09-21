using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.DDD.Abstraction
{
    public class BaseDefinitionEntity:BaseEntity
    {
        public Guid CreatedBy { get; set; }

        public Guid ModifiedBy { get; set; }
    }
}
