using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquorStore.NET._7.MVC.Models.Entities;

public class Liquor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required]
    [StringLength(50)]
    public string? Description { get; set; }
    [Required]
    public float Alcohol { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [StringLength(150)]
    public string? Image { get; set; }

    public int BrandId { get; set; }
    [ForeignKey(nameof(BrandId))]
    public virtual Brand? Brand { get; set; }

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual Category? Category { get; set; }

    public virtual ICollection<LiquorCoctel>? LiquorCoctels { get; set; }
}