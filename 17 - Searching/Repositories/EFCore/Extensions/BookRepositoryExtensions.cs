using Entities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint maxPrice)
        {
            var filterBooks = books.Where(book => book.Price >= minPrice && book.Price <= maxPrice);

            return filterBooks;
        }

        public static IQueryable<Book> Search(this IQueryable<Book> books , string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return books;

             var lowerCaseTerm = searchTerm.Trim().ToLower();

            return books.Where(b => b.Title.ToLower().Contains(searchTerm));
        }

    }
}
