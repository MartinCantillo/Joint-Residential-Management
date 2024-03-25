using ModelsRoles.Roles;

namespace RepositoriesIRoles.IRoles
{
    public interface IRoles
    {
        public Task SaveRol(Roles rol);
        public Task DeleteRol(Roles rol);
        public Task<ICollection<Roles>> GetAll();
    }

}