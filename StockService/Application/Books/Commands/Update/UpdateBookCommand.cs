namespace StockService.Application.Books.Commands.Update
{
    public class UpdateBookCommand
    {
        public string Name { get; set; }
        public string Autor { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
