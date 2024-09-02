using FLexElectronicsShop.Model;

namespace FLexElectronicsShop.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required IFormFile? URL { get; set; }
        public required string Description { get; set; }

        public required int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
