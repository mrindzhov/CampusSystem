namespace CampusSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Campus
    {
        public Campus()
        {
            this.Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }
        [StringLength(4)]
        public string Number { get; set; }
        public int UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}
