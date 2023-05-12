using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquorStore.NET._7.MVC.Models.Entities;

public class Brand
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

    public virtual ICollection<Liquor>? Liquors { get; set; }
}