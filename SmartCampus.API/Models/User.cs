using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SmartCampus.API.Models
{
    public class User : IdentityUser<int> 
    {
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public UserRole Role { get; set; }
    }
}
