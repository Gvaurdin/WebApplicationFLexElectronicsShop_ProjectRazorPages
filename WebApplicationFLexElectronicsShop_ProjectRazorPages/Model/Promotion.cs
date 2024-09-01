using System.ComponentModel.DataAnnotations;

namespace FLexElectronicsShop.Model
{
    public class Promotion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле \"Название акции\"")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 100, ErrorMessage = "Процент скидки должен быть в диапазоне от 0 до 100")]
        public double DiscountPercentage { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Дата начала акции\"")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Дата окончания акции\"")]
        public DateTime EndDate { get; set; }

        public ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
