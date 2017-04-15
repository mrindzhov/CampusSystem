namespace CampusSystem.Models
{
    using System.Collections.Generic;

    public class Student : Person
    {
        public Student()
        {
            this.Guests = new HashSet<Guest>();
            this.Feedbacks = new HashSet<Feedback>();
        }
        public decimal Obligations { get; set; }

        public bool IsActive { get; set; }
        
        public int UniversityId { get; set; }

        public virtual University University { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
