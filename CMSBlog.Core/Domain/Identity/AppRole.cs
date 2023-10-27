﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBlog.Core.Domain.Identity
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>
    {
        [Required]
        [MaxLength(200)]
        public string DisplayName { get; set; }
    }
}
