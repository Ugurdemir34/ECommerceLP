using Catalogs.Domain.Aggregate.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Persistence.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> opt):base(opt)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
