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
            return _context.Persons.Where(p => p.firstName.Equals(firstName) && p.lastName.Equals(lastName)).ToList();
        }
    }
}
