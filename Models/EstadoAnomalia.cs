using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsReporteAnomalias.ReporteAnomalia;

namespace ModelsEstadoAnomalia.EstadoAnomalia
{
    public class EstadoAnomalia
    {
        public EstadoAnomalia()
        {
        }
        public EstadoAnomalia(string Nombre_Estado, DateTime fechaEstado, ReporteAnomalia reporteAnomaliaId)
        {
            this.Nombre_Estado = Nombre_Estado;
            this.fechaEstado = fechaEstado;
            this.ReporteAnomalia = reporteAnomaliaId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre_Estado { get; set; }
        [Required]
        public DateTime fechaEstado { set; get; }

        [ForeignKey("Id_ReporteA")]
        public ReporteAnomalia ReporteAnomalia { set; get; }

    }

}