using MediatR;
using OneOf;
using OneOf.Types;
using StockService.Validation;
using System.ComponentModel.DataAnnotations;

namespace StockService.Application.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<OneOf<Success, ValidationFailed>>
    {
        public string Name { get; set; }
        public string Autor { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
