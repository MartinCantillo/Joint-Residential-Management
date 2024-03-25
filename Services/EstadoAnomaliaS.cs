using System.Data.Entity;
using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsEstadoAnomalia.EstadoAnomalia;
using RepositoriesEstadoAnomalia.IEstadoAnomalia;

namespace ServicesEstadoAnomalia.EstadoAnomalias
{
    public class EstadoAnomalias : IEstadoAnomalia
    {
        private readonly DataContext DbContext;

        public EstadoAnomalias(DataContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<ICollection<EstadoAnomalia>> GetAll()
        {
            return await this.DbContext.EstadosAnomalia.ToListAsync();
        }

        public async Task<EstadoAnomalia> GetById(int idE)
        {
            if (idE == null || idE == 0)
            {
                throw new Exception("Por favor verifica el id");
            }
            else
            {
                return await this.DbContext.EstadosAnomalia.FirstOrDefaultAsync(p => p.Id == idE);
            }
        }

        public async Task SaveEstado(EstadoAnomalia estado)
        {
            if (estado.fechaEstado == null || estado.Nombre_Estado == "" || estado.ReporteAnomalia == null)
            {
                throw new Exception("Por favor verifica");
            }
            else
            {
                await this.DbContext.EstadosAnomalia.AddAsync(estado);
                await this.DbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateEstado(EstadoAnomalia estado, int idE)
        {
            if (estado == null || idE == 0)
            {
                throw new Exception("Por favor verifica");
            }
            else
            {
                var EFound = await GetById(idE);
                if (EFound == null)
                {
                    throw new Exception("Estado no encontrado");
                }
                else
                {
                    EFound.fechaEstado = estado.fechaEstado;
                    EFound.Nombre_Estado = estado.Nombre_Estado;
                    EFound.ReporteAnomalia = estado.ReporteAnomalia;

                    await this.DbContext.SaveChangesAsync();
                }
            }
        }
    }
}