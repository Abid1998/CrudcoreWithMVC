using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudcoreWithMVC.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public String Name { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategotyId")]
        public Category Category { get; set; }
    }
}
