using Avaliacao1.JonStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1.JonStore.Domain.Contracts.Response
{
    public class GetAllProductsResponseModel
    {
        public List<Product> Products { get; set; }
    }
}
