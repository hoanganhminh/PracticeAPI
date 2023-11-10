namespace PracticeAPI.Models.Data.RequestDTO
{
    public class ProductRequestDTO
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int? CategoryId { get; set; }

        public bool? Discontinued { get; set; }
    }
}
