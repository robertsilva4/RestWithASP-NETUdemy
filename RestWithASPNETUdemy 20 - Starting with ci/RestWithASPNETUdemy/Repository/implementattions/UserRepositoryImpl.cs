using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.implementattions
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySQLContext _context;
        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
