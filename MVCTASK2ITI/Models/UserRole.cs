using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTASK2ITI.Models
{
    [PrimaryKey("UserId", "RoleId")]
    public class UserRole
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public User user { get; set; }
        public Role role { get; set; }

    }
}
