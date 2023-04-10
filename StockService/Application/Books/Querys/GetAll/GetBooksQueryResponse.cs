using System.ComponentModel.DataAnnotations;

namespace StockService.Application.Books.Querys.GetAll
{
    public class GetBooksQueryResponse
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Autor { get; set; }
       public string Publisher { get; set; }
       public DateTime ReleaseDate { get; set; }
    }
}
