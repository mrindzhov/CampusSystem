namespace CampusSystem.Models
{
    using System;

    public class Guest : Person
    {
        public Guest()
        {
            this.DateVisited = DateTime.Now;
        }

        public DateTime DateVisited { get; set; }

        public DateTime? DateLeft { get; set; }

        public int? StudentVisitedId { get; set; }

        public virtual Student StudentVisited { get; set; }
    }
}
