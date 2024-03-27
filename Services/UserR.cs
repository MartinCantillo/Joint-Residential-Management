using System.Data.Entity;
using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUser.Usern;
using RepositoriesIUser;

namespace Model.Usern
{
    public class UserService : IUser
    {

        private readonly DataContext DbContext;

        public UserService(DataContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task DeleteUser(int Iduser)
        {
            if (Iduser == null || Iduser == 0)
            {
                throw new ArgumentException("El Id de usuario proporcionado no es válido.");
            }
            else
            {
                var user = await GetById(Iduser);
                if (user != null)
                {
                    this.DbContext.Users.Remove(user);
                    this.DbContext.SaveChanges();
                }
            }

        }

        public ICollection<User> GetAll()
        {
            return this.DbContext.Users.ToList();
        }

        public async Task<User> GetById(int idUser)
        {
            return await this.DbContext.Users.FirstOrDefaultAsync(p => p.Id_User == idUser);
        }

        public async Task SaveUser(User user)
        {
            if (user.Username == "" || user.Password == "" || user.Roles == "")
            {
                throw new Exception("Por favor verifica");

            }
            else
            {
                try
                {
                    Console.WriteLine($"entro {user.Roles}");
                    await DbContext.Users.AddAsync(user);
                    this.DbContext.SaveChanges();
                }
                catch (System.Exception)
                {

                    throw;
                }


            }
        }

        public async Task<User> Update(int idUser, User user)
        {

            if (idUser == 0)
            {
                throw new Exception("Por favor valida el Id");
            }
            else
            {
                var userFound = await GetById(idUser);
                if (userFound == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                else
                {
                    // Actualizo los datos del usuario con los nuevos datos proporcionados
                    userFound.Username = user.Username;
                    userFound.Password = user.Password;
                    userFound.Roles = user.Roles;
                    //Guardo los cambios
                    await this.DbContext.SaveChangesAsync();
                    return userFound;
                }
            }
        }
    }

}