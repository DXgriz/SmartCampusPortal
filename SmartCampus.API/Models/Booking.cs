using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.API.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } 

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}
