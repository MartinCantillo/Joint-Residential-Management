

using ModelsUser.Usern;

namespace RepositoriesIAuthenticationUser.IAuthenticationUser
{
    public interface IAuthenticationUser
    {

        public string GenerateToken(int id, string nombre, string roles);
        public User ValidateUser(string user,string password);

    }

}