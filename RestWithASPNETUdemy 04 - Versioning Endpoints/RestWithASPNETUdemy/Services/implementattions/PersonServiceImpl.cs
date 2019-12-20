using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNETUdemy.Services.implementattions
{
    public class PersonServiceImpl : IPersonService
    {
        private MySQLContext _context;
        public PersonServiceImpl(MySQLContext context)
        {
            _context = context;
        }


        //Método responsável por gerar uma nova pessoa
        //caso houesse um banco de dados seria necessário persistir nos dados
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }


        //Método responsável por retornar todas as pessoas 
        //porém as pessoas no momento são mockus
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        //Método responsáve por retornar uma pessoa
        //como não acessamos o banco de dados estamos retornando um mock
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        //Método de atualizar as pessoas
        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }
        //Método responsável por deletar uma pessoa através do ID
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
