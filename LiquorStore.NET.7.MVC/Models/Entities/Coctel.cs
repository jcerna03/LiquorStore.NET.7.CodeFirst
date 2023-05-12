using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquorStore.NET._7.MVC.Models.Entities;

public class Coctel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required]
    [StringLength(100)]
    public string? Description { get; set; }
    public string? Image { get; set; }

    public ICollection<Ingredient>? Ingredients { get; set; }
    public ICollection<Preparation>? Preparations { get; set; }
    public virtual ICollection<LiquorCoctel>? LiquorCoctels { get; set; }
}