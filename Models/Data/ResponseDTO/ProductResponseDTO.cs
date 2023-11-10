using PracticeAPI.Models;

namespace PracticeAPI.Models.Data.ResponseDTO
{
    public class ProductResponseDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public bool? Discontinued { get; set; }

    }
}
