using System.ComponentModel.DataAnnotations;

namespace FLexElectronicsShop.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Название\"")]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле \"Ссылка на продукт\"")]
        public required string URL { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Описание продукта\"")]
        public required string Description { get; set; }

        public required int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
