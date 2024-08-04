using System.ComponentModel.DataAnnotations;

namespace FLexElectronicsShop.Model
{
    public class Product
    {
        public required int Id { get; set; }

        [Required(ErrorMessage = "Вы не заполнили поле \"Название\"")]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле \"Ссылка на фильм\"")]
        public required string URL { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле \"Название\"")]
        [Range(100,1000000)]
        public double Price { get; set; }
    }
}
