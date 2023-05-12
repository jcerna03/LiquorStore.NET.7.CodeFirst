using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquorStore.NET._7.MVC.Models.Entities;

public class LiquorCoctel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int LiquorId { get; set; }
    [ForeignKey(nameof(LiquorId))]
    public Liquor? Liquor { get; set; }

    public int CoctelId { get; set; }
    [ForeignKey(nameof(CoctelId))]
    public Coctel? Coctel { get; set; }
}