using System.ComponentModel.DataAnnotations;

namespace FLexElectronicsShop.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле \"Название категории\"")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле \"Описание категории\"")]
        public required string Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
