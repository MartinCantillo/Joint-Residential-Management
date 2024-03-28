using ModelsReporteAnomalias.ReporteAnomalia;

namespace RepositoriesIReporteAnomalia
{
    public interface IReporteAnomalia
    {
        public Task SaveReporte(ReporteAnomalia r);
        public ReporteAnomalia GetReporteById(int id);

        public void  DeleteReporte(int id);
        public ICollection<ReporteAnomalia> GetAllByResidente(int id);
        public Task GetAll();


    }
}