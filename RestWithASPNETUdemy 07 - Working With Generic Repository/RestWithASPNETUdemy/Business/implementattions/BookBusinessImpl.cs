using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.implementattions
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;
        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }
        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
