using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.API.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public User Author { get; set; }
    }

}
