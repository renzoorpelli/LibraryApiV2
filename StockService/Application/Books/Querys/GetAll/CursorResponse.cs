namespace StockService.Application.Books.Querys.GetAll
{
    public sealed record CursorResponse<T>(long? Cursor, T Data);
}
