using System.ComponentModel.DataAnnotations;

namespace MVCTASK2ITI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public List<UserRole> Roles { get; set; } = new();
        public List<Post> Posts { get; set; } = new();


    }
}
