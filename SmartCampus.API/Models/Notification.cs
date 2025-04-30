using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.API.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; }      // e.g., "booking", "issue", "announcement"
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
