using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Common.Dtos
{
    public class CategoryDto
    {
        [JsonProperty]
        public Guid Id { get; private set; }
        [JsonProperty]

        public string Title { get; set; }
        [JsonProperty]

        public string Description { get; set; }
        [JsonProperty]

        public DateTime CreatedDate { get; private set; }
        [JsonProperty]

        public DateTime ModifiedDate { get; private set; }
        [JsonProperty]

        public bool IsDeleted { get; private set; }

    }
}
