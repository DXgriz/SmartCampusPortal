using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.API.Models
{
    public class Timetable
    {
        [Key]
        public int TimetableId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CourseName { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Location { get; set; }
        [Required]
        public int LecturerId { get; set; }

        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }
        [NotMapped]
        public List<int> StudentIds { get; set; }
    }
}
