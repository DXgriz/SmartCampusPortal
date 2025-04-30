using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.API.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Location { get; set; }
        public int? Capacity { get; set; }
        public bool Availability { get; set; }
    }
}
