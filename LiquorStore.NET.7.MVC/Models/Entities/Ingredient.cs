using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquorStore.NET._7.MVC.Models.Entities;

public class Ingredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Description { get; set; }

    public int CoctelId { get; set; }
    [ForeignKey(nameof(CoctelId))]
    public Coctel? Coctel { get; set; }
}