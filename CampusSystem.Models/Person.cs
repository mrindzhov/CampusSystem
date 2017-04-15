namespace CampusSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Person
    {
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname should be between 2 and 50 characters!")]
        public string FirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "MiddleName should be between 2 and 50 characters!")]
        public string MiddleName { get; set; }

        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "LastName should be between 2 and 50 characters!")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.MiddleName} {this.LastName}";

        public int TownId { get; set; }

        public virtual Town Town { get; set; }
    }
}
