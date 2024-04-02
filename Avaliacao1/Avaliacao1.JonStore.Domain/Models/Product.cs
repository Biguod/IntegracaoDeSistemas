using Avaliacao1.JonStore.Domain.Models.Common;

namespace Avaliacao1.JonStore.Domain.Models
{
    public class Product : BaseClass
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
    }
}
