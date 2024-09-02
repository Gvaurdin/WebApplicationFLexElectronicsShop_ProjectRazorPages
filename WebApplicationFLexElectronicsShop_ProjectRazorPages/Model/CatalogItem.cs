using System.ComponentModel.DataAnnotations;

namespace FLexElectronicsShop.Model
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Стоимость\"")]
        [Range(100, 1000000)]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Количество на складе не может быть отрицательным")]
        public int Stock { get; set; }

        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public bool IsAvailable { get; set; }

        public double DiscountedPrice { get; set; }

        public static double ApplyDiscount(Promotion promotion,double discountedPrice, double price)
        {
            if (promotion != null && promotion.StartDate <= DateTime.Now && promotion.EndDate >= DateTime.Now)
            {
                discountedPrice = price * (1 - promotion.DiscountPercentage / 100);
            }
            else
            {
                discountedPrice = 0;
            }

            return discountedPrice;
        }
    }
}
