using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.implementattions
{
    public class BookRepositoryImpl : IBookRepository
    {
        private MySQLContext _context;
        public BookRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }


        //Método responsável por gerar uma nova pessoa
        //caso houesse um banco de dados seria necessário persistir nos dados
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return book;
        }


        //Método responsável por retornar todas as pessoas 
        //porém as pessoas no momento são mockus
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        //Método responsáve por retornar uma pessoa
        //como não acessamos o banco de dados estamos retornando um mock
        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
        }

        //Método de atualizar as pessoas
        public Book Update(Book book)
        {
            if (!Exist(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(book.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return book;
        }
        //Método responsável por deletar uma pessoa através do ID
        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(long? id)
        {
            return _context.Books.Any(b => b.Id.Equals(id));
        }
    }
}
