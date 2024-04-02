using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1.JonStore.Domain.Contracts.Request
{
    public class UpdateProductRequestModel : InsertProductRequestModel
    {
        public Guid Id { get; set; }
    }
}
