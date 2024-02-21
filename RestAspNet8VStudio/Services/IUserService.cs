using RestAspNet8VStudio.Model;

namespace RestAspNet8VStudio.Services
{
    public interface IUserService
    {
        List<User> FindAll();
        User FindByID(long id);
        User Create(User user);
        User Update(User user);
        void Delete(long id);
    }
}
