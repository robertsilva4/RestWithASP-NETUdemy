using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository.Generic
{
    //A implementação do repositório generico
    //recebe qulquer tipo T que implementa IRepository de mesmo tipo
    //Desde que T extenda BaseEntity
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;
        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        //Método responsável por gerar um novo item
        //e persistir nos dados
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    dataset.Remove(result);
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
            return dataset.Any(i => i.Id.Equals(id));
        }

        //Método responsável por retornar todas os itens 
        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        //Método responsáve por retornar um item
        public T FindById(long id)
        {
            return dataset.SingleOrDefault(i => i.Id.Equals(id));
        }

        //Método de atualizar as itens existentes
        public T Update(T item)
        {
            if (!Exist(item.Id)) return null;

            var result = dataset.SingleOrDefault(i => i.Id.Equals(item.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }
    }
}
