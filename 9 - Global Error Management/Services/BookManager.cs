﻿using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;

        private readonly ILoggerService _logger;

        public BookManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public Book CreateOneBook(Book book)
        {
            if(book is null)
            {

                _logger.LogError("the book schema does not correct");
                
                throw new ArgumentNullException(nameof(book));

            }
            
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id , trackChanges);

            if (entity is null)

            {
                string message = $"book with id : {id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);

            }

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();

                
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);

            if (entity == null)
            {
                string message = $"book with id : {id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            return entity;
        }

        public void UpdateOneBook(int Id , Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(Id, trackChanges);

            if (entity == null)
            {
                string message = $"book with id : {Id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }

            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.Update(entity);
            _manager.Save();

        }
    }
}
