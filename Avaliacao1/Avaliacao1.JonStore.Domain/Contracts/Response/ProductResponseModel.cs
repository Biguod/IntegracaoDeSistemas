using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1.JonStore.Domain.Contracts.Response
{
    public class ProductResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
    }
}
