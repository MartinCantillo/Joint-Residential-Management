
using Microsoft.EntityFrameworkCore;
using ModelResidente.Residente;
using ModelsEstadoAnomalia.EstadoAnomalia;
using ModelsReporteAnomalias.ReporteAnomalia;
using ModelsUser.User;

namespace DataDataContext.DataContext
{
    public class DataContext : DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Residente> Residentes { set; get; }
        public DbSet<ReporteAnomalia> ReporteAnomalias { set; get; }
         public DbSet<EstadoAnomalia> EstadosAnomalia { set; get; }
        
    }
}