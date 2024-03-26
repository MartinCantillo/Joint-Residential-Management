using ModelResidente.Residente;

namespace RepositoriesIResidente.IResidente
{

    public interface IResidente
    {

        public Task SaveResidente(Residente r);
        public Task<ICollection<Residente>> GetAll();
        public Task<Residente>GetById(int id);
        public Task Update(int id, Residente r);
    }
}