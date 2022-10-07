using API.Models.ModelDBs;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Account
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? ResetPasswordToken  { get; set; }
        public DateTime? ResetTokenExpires { get; set; }

        //
        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Admin? Admin { get; set; }
        public virtual ICollection<ForumThread> ForumThreads { get; set; }
    }
}
