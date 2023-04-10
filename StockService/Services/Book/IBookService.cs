using OneOf;
using OneOf.Types;
using StockService.Application.Books.Commands.Create;
using StockService.Application.Books.Commands.Update;
using StockService.Validation;
using BookDomain = StockService.Domain.Entities.Book;
namespace StockService.Services.Book
{
    public interface IBookService
    {
        /// <summary>
        /// validar que el Libro recibido cumpla la serie de reglas establecidas en BookRequestValidator<> de no ser asi lanza la excepcion
        /// </summary>
        /// <param name="commandBook"></param>
        /// <returns></returns>
        Task<OneOf<Success, ValidationFailed>> Create(BookDomain book);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        OneOf<Success, NotFound> Delete(int bookId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandBook"></param>
        /// <returns></returns>
        Task<OneOf<BookDomain, NotFound, ValidationFailed>> Update(BookDomain book, int idBook);

    }
}
