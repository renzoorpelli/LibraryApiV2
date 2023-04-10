using MediatR;

namespace StockService.Application.Books.Commands.Delete
{
    public class DeleteBookCommand 
    {
        public int Id { get; set; }
    }
}
