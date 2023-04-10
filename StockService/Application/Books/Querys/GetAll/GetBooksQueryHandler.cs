using Azure.Core;
using Dapper;
using MediatR;
using StockService.Infrastructure.Data;
using System.Data;

namespace StockService.Application.Books.Querys.GetAll
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, CursorResponse<IEnumerable<GetBooksQueryResponse>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBooksQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<CursorResponse<IEnumerable<GetBooksQueryResponse>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            if(request.Cursor is not 0 || request.PageSize is not 0)
            {
                IReadOnlyList<GetBooksQueryResponse> libros =
                      _sqlConnectionFactory
                      .SqlCreateConnection()
                      .Query<GetBooksQueryResponse>("getBooks", CommandType.StoredProcedure)
                      .Where(b => b.Id > request.Cursor)
                      .Take(request.PageSize + 1)
                      .OrderBy(b => b.Id)
                      .ToList();

                long cursor = libros[^1].Id;

                List<GetBooksQueryResponse> response = libros.Take(request.PageSize).ToList();

                return new CursorResponse<IEnumerable<GetBooksQueryResponse>>(cursor, response);
            }
            IReadOnlyList<GetBooksQueryResponse> responseAll =
                      _sqlConnectionFactory
                      .SqlCreateConnection()
                      .Query<GetBooksQueryResponse>("getBooks", CommandType.StoredProcedure)
                      .OrderBy(b => b.Id)
                      .ToList();

            return new CursorResponse<IEnumerable<GetBooksQueryResponse>>(responseAll.Count,responseAll);

        }


    }
}
