﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ford.WebApi.Data.Entities
{
    public partial class HorseOwner
    {
        [Key]
        public long HorseId { get; set; }
        [Key]
        [Column(TypeName = "nvarchar(40)")]
        public long UserId { get; set; }
        [Column(TypeName = "nvarchar(8)")]
        public string RuleAccess { get; set; } = null!;

        [ForeignKey("UserId")]
        [InverseProperty("HorseOwners")]
        public virtual User User { get; set; } = null!;
        [ForeignKey("HorseId")]
        [InverseProperty("HorseOwners")]
        public virtual Horse Horse { get; set; } = null!;
    }

    public enum OwnerRole
    {
        // Only read saves and other info about horse
        Read = 0,
        // Read/Write info about horse and add/edit other saves
        Write = 1,
        // Also add/remove other users to horse
        All = 2,
        // There can only be one creator
        Creator = 3
    }
}
