using System.ComponentModel.DataAnnotations;
using University.Models;

namespace WebApiPerson.Models
{

    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }

    public class Course : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        public Level Lvl { get; set; } = Level.Basic;

        //Relación, un Curso puede tener varias Categorias. Hacer la relación desde el lado de categoria
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

        [Required]
        public Chapter Chapter { get; set; } = new Chapter();
    }
}
