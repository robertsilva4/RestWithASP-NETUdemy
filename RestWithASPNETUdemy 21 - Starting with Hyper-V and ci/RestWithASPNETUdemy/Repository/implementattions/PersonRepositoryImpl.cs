using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.implementattions
{
    public class PersonRepositoryImpl : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepositoryImpl(MySQLContext context) : base (context) {}
        public List<Person> FindByName(string firstName, string lastName)
        {
            if(!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.persons.Where(p => p.firstName.Contains(firstName) && p.lastName.Contains(lastName)).ToList();
            }

            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.persons.Where(p => p.lastName.Contains(lastName)).ToList();
            }

            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.persons.Where(p => p.firstName.Contains(firstName)).ToList();
            }

            else
            {
                return _context.persons.ToList();
            }
        }
    }
}
