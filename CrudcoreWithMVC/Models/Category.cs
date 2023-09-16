using Microsoft.Build.Framework;

namespace CrudcoreWithMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}