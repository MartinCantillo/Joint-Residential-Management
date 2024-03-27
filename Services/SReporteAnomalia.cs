using System.Data.Entity;
using DataDataContext.DataContext;
using ModelsReporteAnomalias.ReporteAnomalia;
using RepositoriesIReporteAnomalia;

namespace RepositoriesSReporteAnomalia.SReporteAnomalia
{
    public class SReporteAnomalia : IReporteAnomalia
    {
        private readonly DataContext _DataContext;

        public SReporteAnomalia(DataContext _DataContext)
        {
            this._DataContext = _DataContext;

        }

        public async Task DeleteReporte(int id)
        {
            if (id == 0)
            {
                throw new Exception("Por favor verifica el id");
            }
            else
            {
                var ReporteFound = await GetReporteById(id);
                if (ReporteFound == null)
                {
                    throw new Exception("Reporte no encontrado");
                }
                else
                {
                    this._DataContext.ReporteAnomalias.Remove(ReporteFound);
                    this._DataContext.SaveChanges();
                }
            }
        }

        public async Task GetAll() => await this._DataContext.ReporteAnomalias.ToListAsync();


        public async Task<ICollection<ReporteAnomalia>> GetAllByResidente(int id)
        {
            if (id == 0)
            {
                throw new Exception("por favor verifica el id");
            }
            else
            {
                var ReportesFound = await this._DataContext.ReporteAnomalias.Where(p => p.Residente == id).ToListAsync();
                return ReportesFound;
            }
        }

        public async Task<ReporteAnomalia> GetReporteById(int id)
        {
            if (id == 0)
            {
                throw new Exception("Por favor verifica el id");
            }
            else
            {
                return await this._DataContext.ReporteAnomalias.FirstOrDefaultAsync(p => p.Id_ReporteA == id);
            }
        }

        public Task SaveReporte(ReporteAnomalia r)
        {
            if (r.AsuntoAnomalia == "" || r.DescripcionAnomalia == "" || r.FechaReporteAnomalia == null
            || r.FotoAnomalia == "" || r.Residente == 0 || r.TipoAnomalia == "")
            {
                
                throw new Exception("Por favor verifica los datos");
                
            }
            else
            {
                Console.WriteLine("entro al servicio ");
                _DataContext.ReporteAnomalias.Add(r);
                _DataContext.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}