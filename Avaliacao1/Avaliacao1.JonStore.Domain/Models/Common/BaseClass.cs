using System.ComponentModel.DataAnnotations;

namespace Avaliacao1.JonStore.Domain.Models.Common
{
    public class BaseClass
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
    }
}
