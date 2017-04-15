namespace CampusSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public Town()
        {
            this.Students = new HashSet<Student>();
        }
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "Town name should be between 2 and 50 characters!")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}