namespace CampusSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}