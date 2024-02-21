using RestAspNet8VStudio.Model;
using RestAspNet8VStudio.Model.Context;
using System.Threading;

namespace RestAspNet8VStudio.Services.Implementations
{
    public class UserServiceImplementation : IUserService
    {
        private PostgreSQLContext _context;

        public UserServiceImplementation(PostgreSQLContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return user;
        }

        public void Delete(long id)
        {
            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Users.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<User> FindAll()
        {
            return _context.Users.ToList();
        }
        public User FindByID(long id)
        {
            return _context.Users.SingleOrDefault(u => u.Id.Equals(id));
        }

        public User Update(User user)
        {
            if (!Exists(user.Id)) return new User();
            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }
        private bool Exists(long id)
        {
            return _context.Users.Any(u => u.Id.Equals(id));
        }
    }
}
