namespace CampusSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Room
    {
        public Room()
        {
            this.Students = new HashSet<Student>();
            this.Feedbacks = new HashSet<Feedback>();
        }
        //[StringLength(4)]
        //[Key, Column(Order = 2)]
        public string Number { get; set; }
        //[Key, Column(Order = 1)]
        public int CampusId { get; set; }
        //[ForeignKey("CampusId, Number")]
        public virtual Campus Campus { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}