using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETWebAppMVCStudentApp.Models
{
    [Table("tblUser")]
    public class tblUser
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        // SHA-256 cua mat khau (khong luu mat khau dang plain text)
        [Required]
        public byte[] PasswordHash { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }
    }
}
