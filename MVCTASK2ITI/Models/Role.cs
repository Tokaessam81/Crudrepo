using System.ComponentModel.DataAnnotations;

namespace MVCTASK2ITI.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<UserRole> Users { get; set; } = new();
    }
}
