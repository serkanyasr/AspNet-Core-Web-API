using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContex _contex;
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(RepositoryContex contex)
        {
            _contex = contex;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_contex));
        }

        public IBookRepository Book => _bookRepository.Value;

        public void Save()
        {
            _contex.SaveChanges();
        }
    }
}
