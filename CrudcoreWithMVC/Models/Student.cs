using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudcoreWithMVC.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        //Database Columname Set and DataAnnotations Requured Validetion

        [Column("StudentName", TypeName = "Varchar(100)")]
        [Required]
        public string Name { get; set; }

        //Database Columname Set
        [Column("StudentGender", TypeName = "Varchar(20)")]

        [Required]
        public string Gender { get; set; }

        [Required]
        // ? is nullable 
        public int? Age { get; set; }

        //Database Update New Column Add In Database 
        [Required]
        public int? Standard { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
    }
}
