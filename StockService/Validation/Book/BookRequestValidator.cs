using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.AspNetCore.Rewrite;
using StockService.Application.Books.Commands.Create;
using BookDomain = StockService.Domain.Entities.Book;

namespace StockService.Validation.Book;

public partial class BookRequestValidator : AbstractValidator<BookDomain>
{
    public BookRequestValidator()
    {
        RuleFor(x => x.Name )
            .Matches(StringValidatorRegex())
            .WithMessage("The Book Name is not valid.");
        RuleFor(x => x.Autor )
            .Matches(FullNameRegex())
            .WithMessage("The Autor name is not valid.");
        RuleFor(x => x.Publisher )
            .Matches(StringValidatorRegex())
            .WithMessage("The Publisher name is not valid.");

        RuleFor(x => x.ReleaseDate)
            .LessThan(DateTime.Now)
            .WithMessage("The date of release cannot be in the future.");

    }

    [GeneratedRegex(@"^[A-Za-z0-9][A-Za-z0-9]{0,98}[A-Za-z0-9]$", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex StringValidatorRegex();
    
    
    [GeneratedRegex("^[a-z ,.'-]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex FullNameRegex();
}