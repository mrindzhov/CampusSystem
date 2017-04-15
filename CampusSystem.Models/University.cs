namespace CampusSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class University
    {
        public University()
        {
            this.Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "University name should be between 2 and 100 characters!")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students{ get; set; }
    }
}