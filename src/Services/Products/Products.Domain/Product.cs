using ECommerceLP.Domain.Entities;

namespace Products.Domain
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

    }
}