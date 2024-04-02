namespace Avaliacao1.JonStore.Domain.Contracts.Request
{
    public class InsertProductRequestModel
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
    }
}
