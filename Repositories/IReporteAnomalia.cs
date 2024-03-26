using ModelsReporteAnomalias.ReporteAnomalia;

namespace RepositoriesIReporteAnomalia
{
    public interface IReporteAnomalia
    {
        public Task SaveReporte(ReporteAnomalia r);
        public Task<ReporteAnomalia> GetReporteById(int id);

        public Task DeleteReporte(int id);
        public Task<ICollection<ReporteAnomalia>> GetAllByResidente(int id);
        public Task GetAll();


    }
}