﻿using Entities.Models;
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


        public IQueryable<Book> GetAllBooks(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(x => x.Id);

        public Book GetOneBookById(int Id, bool trackChanges) =>
            FindByCondition(b => b.Id.Equals(Id), trackChanges).SingleOrDefault();

        public void UpdateOneBook(Book book) => Update(book);

    }
}
