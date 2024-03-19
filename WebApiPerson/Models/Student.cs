using System.ComponentModel.DataAnnotations;
using WebApiPerson.Models;

namespace University.Models
{
    public class Student: BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DayOfBirth { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
