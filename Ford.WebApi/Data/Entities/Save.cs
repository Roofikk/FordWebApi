﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ford.WebApi.Data.Entities;

public partial class Save
{
    public Save()
    {
        SaveBones = new HashSet<SaveBone>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long SaveId { get; set; }
    public long HorseId { get; set; }
    [Column(TypeName = "nvarchar(30)")]
    public string Header { get; set; }
    [Column(TypeName = "TEXT")]
    public string? Description { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [ForeignKey("HorseId")]
    [InverseProperty("Saves")]
    public virtual Horse Horse { get; set; }
    [InverseProperty("Save")]
    public virtual ICollection<SaveBone> SaveBones { get; set; }
}
