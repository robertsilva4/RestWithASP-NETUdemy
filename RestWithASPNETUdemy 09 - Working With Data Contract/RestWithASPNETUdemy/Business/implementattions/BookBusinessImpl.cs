using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.implementattions
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;

        private readonly BookConverter _converter;
        
        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }


        //Método responsável por gerar uma nova pessoa
        //caso houesse um banco de dados seria necessário persistir nos dados
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }


        //Método responsável por retornar todas as pessoas 
        //porém as pessoas no momento são mockus
        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        //Método responsáve por retornar uma pessoa
        //como não acessamos o banco de dados estamos retornando um mock
        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        //Método de atualizar as pessoas
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
        //Método responsável por deletar uma pessoa através do ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        public bool Exist(long id)
        {
            return _repository.Exist(id);
        }
    }
}
