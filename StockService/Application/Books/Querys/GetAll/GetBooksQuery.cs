using MediatR;

namespace StockService.Application.Books.Querys.GetAll
{
    public sealed class GetBooksQuery : IRequest<CursorResponse<IEnumerable<GetBooksQueryResponse>>>
    {
        public long Cursor { get; set; }
        public int PageSize { get; set; }
    }
}
