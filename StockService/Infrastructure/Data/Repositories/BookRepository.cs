using StockService.Domain.Entities;
using StockService.Infrastructure.Data;
using StockService.Infrastructure.Data.Repositories.Generic;

namespace StockService.Infrastructure.Data.Repositories;

public class BookRepository : IRepository
{
    private readonly ApplicationDbContext context;

    public BookRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public bool Check(int idBook)
    {
        return context.Books.Any(x => x.Id == idBook);
    }

    public void Create(Book book)
    {
        context.Books.Add(book);
    }

    public bool Delete(int idBook)
    {
        Book? book = context.Books.FirstOrDefault(x => x.Id == idBook);
        if (book is null)
        {
            return false;
        }
        context.Books.Remove(book);
        return true;
    }

    public bool Update(Book bookUpdated, int id)
    {
        if (bookUpdated is not null)
        {
            context.Books.Update(bookUpdated);// TODO verificar si funciona
            return true;
        }
        return false;
    }
}