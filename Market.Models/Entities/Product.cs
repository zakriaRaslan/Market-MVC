using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Market.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(255)]
        public required string Title { get; set; }
        [StringLength(2500)]
        public required string Description { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Image { get; set; }
    }
}
