using AutoMapper;
using StockService.Application.Books.Commands.Create;
using StockService.Application.Books.Querys.GetAll;
using BookDomain = StockService.Domain.Entities.Book;

namespace StockService.Profiles.Book;

public class BookProfile : Profile
{
    public BookProfile()
    {
       CreateMap<CreateBookCommand, BookDomain>();
    }
}