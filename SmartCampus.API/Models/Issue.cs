using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.API.Models
{
    public class Issue
    {
        [Key]
        public int IssueId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Location { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Severity { get; set; } // e.g., "low", "medium", "high"
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }    // e.g., "reported", "assigned", "resolved"
        [Required]
        public int ReportedBy { get; set; }
        public int? AssignedTo { get; set; } // Nullable, as an issue might not be assigned initially

        [ForeignKey("ReportedBy")]
        public User Reporter { get; set; }
        [ForeignKey("AssignedTo")]
        public User Assignee { get; set; }
    }
}
