using System.ComponentModel.DataAnnotations;

namespace APW.Web.Models
{
    public class ProductViewModel //objeto que se utiliza para la vista, no tiene que ver precisamente con un objeto tal cual. Puede comprender muchos modelos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
    }
}
