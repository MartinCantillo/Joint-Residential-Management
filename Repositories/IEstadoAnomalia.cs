using ModelsEstadoAnomalia.EstadoAnomalia;

namespace RepositoriesEstadoAnomalia.IEstadoAnomalia
{
    public interface IEstadoAnomalia
    {
        public Task SaveEstado(EstadoAnomalia estado);
        public Task UpdateEstado(EstadoAnomalia estado, int idE);
        public Task<EstadoAnomalia> GetById(int idE);
        public Task<ICollection<EstadoAnomalia>> GetAll();



    }

}