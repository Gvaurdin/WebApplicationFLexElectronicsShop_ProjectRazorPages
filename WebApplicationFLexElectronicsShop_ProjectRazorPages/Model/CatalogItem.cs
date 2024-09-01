using System.ComponentModel.DataAnnotations;

namespace FLexElectronicsShop.Model
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Стоимость\"")]
        [Range(100, 1000000)]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Количество на складе не может быть отрицательным")]
        public int Stock { get; set; }

        public int? PromotionId { get; set; }
        public Promotion Promotion { get; set; }

        public bool IsAvailable { get; set; }

        public double DiscountedPrice { get; set; }

        public void ApplyDiscount()
        {
            if (Promotion != null && Promotion.StartDate <= DateTime.Now && Promotion.EndDate >= DateTime.Now)
            {
                DiscountedPrice = Price * (1 - Promotion.DiscountPercentage / 100);
            }
            else
            {
                DiscountedPrice = Price;
            }
        }
    }
}
