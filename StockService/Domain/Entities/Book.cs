using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace StockService.Domain.Entities;

public class Book
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Autor { get; set; }
    [Required] public string Publisher { get; set; }
    [Required] public DateTime ReleaseDate { get; set; }
}