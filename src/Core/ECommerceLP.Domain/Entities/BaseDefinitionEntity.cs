using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Domain.Entities
{
    public class BaseDefinitionEntity:BaseEntity
    {
        public Guid CreatedBy { get; set; }

        public Guid ModifiedBy { get; set; }
    }
}
