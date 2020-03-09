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


        //Método responsável por gerar uma nova pessoa
        //caso houesse um banco de dados seria necessário persistir nos dados
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }


        //Método responsável por retornar todas as pessoas 
        //porém as pessoas no momento são mockus
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        //Método responsáve por retornar uma pessoa
        //como não acessamos o banco de dados estamos retornando um mock
        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        //Método de atualizar as pessoas
        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
        //Método responsável por deletar uma pessoa através do ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
