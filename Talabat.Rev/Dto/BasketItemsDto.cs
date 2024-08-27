using System.ComponentModel.DataAnnotations;

namespace Talabat.Rev.Dto
{
    public class BasketItemsDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1,double.MaxValue ,ErrorMessage = "The Price Must be More Than  Zero!")]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [Range(1,double.MaxValue, ErrorMessage = "The Quantity Must be at least  one Item")]
        public int Quantity { get; set; }
    }
}