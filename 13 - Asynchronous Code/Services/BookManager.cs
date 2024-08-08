using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
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

        private readonly IMapper _mapper;


        public BookManager(IRepositoryManager manager, ILoggerService logger ,IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public BookDto CreateOneBook(BookDtoForInsertion bookDto)
        {
            if(bookDto is null)
            {

                _logger.LogError("the book schema does not correct");
                
                throw new ArgumentNullException(nameof(bookDto));

            }
            var entity = _mapper.Map<Book>(bookDto);
            
            _manager.Book.CreateOneBook(entity);
            _manager.Save();
            return _mapper.Map<BookDto>(entity);
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

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
            
            var books = _manager.Book.GetAllBooks(trackChanges);
                
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public BookDto GetOneBookById(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);

            if (entity == null)
            {
                string message = $"book with id : {id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            return _mapper.Map<BookDto>(entity);
        }

        public void UpdateOneBook(int Id , BookDtoUpdate bookDto, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(Id, trackChanges);

            if (entity == null)
            {
                string message = $"book with id : {Id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }

            //Mapping

            //entity.Title = book.Title;
            //entity.Price = book.Price;
            _mapper.Map(entity, bookDto);

            _manager.Book.Update(entity);
            _manager.Save();

        }
    }
}
