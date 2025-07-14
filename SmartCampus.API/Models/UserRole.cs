using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SmartCampus.API.Models
{

    public class UserRole : IdentityRole<int>
    {
        [Key]
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
    }
}
