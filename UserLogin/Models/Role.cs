using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }
    }
}
