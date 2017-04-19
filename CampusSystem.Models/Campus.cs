namespace CampusSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Campus
    {
        public Campus()
        {
            this.Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }
        [StringLength(4)]
        public string Number { get; set; }
        public string Password { get; set; }
        public int UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}
