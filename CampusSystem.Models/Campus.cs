namespace CampusSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Campus
    {
        public Campus()
        {
            this.Rooms = new HashSet<Room>();
            this.Students = new HashSet<Student>();
            this.Guests = new HashSet<Guest>();
        }
        public int Id { get; set; }
        [StringLength(4)]
        public string Number { get; set; }
        [Required]
        public string Password { get; set; }

        public int UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
