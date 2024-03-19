using System.ComponentModel.DataAnnotations;
using WebApiPerson.Models;


namespace University.Models
{
    public class Chapter: BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();
        [Required]
        public string List = string.Empty;
    }
}
