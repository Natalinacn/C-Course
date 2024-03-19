using System.ComponentModel.DataAnnotations;

namespace WebApiPerson.Models
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        //Un curso tiene varias categorias
        public ICollection<Course> Courses { get; set; } = new List<Course>(); 
    }
}
