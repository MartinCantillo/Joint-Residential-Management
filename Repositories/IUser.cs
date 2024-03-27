using ModelsUser.Usern;

namespace RepositoriesIUser
{
    public interface IUser
    {
        public Task SaveUser(User user);
        public Task DeleteUser(int Iduser);
        public Task<User> GetById(int idUser);
        public Task<User> Update(int idUser, User user);
        public ICollection<User> GetAll();

    }

}