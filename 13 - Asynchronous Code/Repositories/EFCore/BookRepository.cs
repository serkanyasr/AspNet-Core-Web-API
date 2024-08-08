﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContex context) : base(context)
        {
            
        }

        public void CreateOneBook(Book book) => Create(book);
        public void DeleteOneBook(Book book) => Delete(book);


        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(x => x.Id)
            .ToListAsync();

        public async Task<Book> GetOneBookByIdAsync(int Id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneBook(Book book) => Update(book);

    }
}
