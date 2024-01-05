using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Market.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(50)]
        [DisplayName("Category Name")]
        public required string Name { get; set; }
    }
}
