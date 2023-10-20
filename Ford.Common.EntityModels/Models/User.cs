﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ford.Common.EntityModels.Models
{
    public partial class User
    {
        public User()
        {
            HorseOwners = new HashSet<HorseOwner>();
        }

        [Key]
        [Column(TypeName = "nvarchar(40)")]
        public string UserId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Login { get; set; } = null!;
        [Column(TypeName = "nvarchar(8)")]
        public string Role { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string PasswordHash { get; set; } = null!;
        [Column(TypeName = "nvarchar(128)")]
        public string? Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? LastName { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string? Phone { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string? City { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string? Region { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string? Country { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<HorseOwner> HorseOwners { get; set; }
    }
}
