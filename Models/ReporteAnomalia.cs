using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelResidente.Residente;

namespace ModelsReporteAnomalias.ReporteAnomalia
{
    public class ReporteAnomalia
    {
        public ReporteAnomalia(string DescripcionAnomalia, string FechaReporteAnomalia,
        string FotoAnomalia, string TipoAnomalia, string AsuntoAnomalia, Residente Residente)
        {
            this.DescripcionAnomalia = DescripcionAnomalia;
            this.FechaReporteAnomalia = FechaReporteAnomalia;
            this.FotoAnomalia = FotoAnomalia;
            this.TipoAnomalia = TipoAnomalia;
            this.AsuntoAnomalia = AsuntoAnomalia;
            this.Residente = Residente;
            Estados = ["Pendiente"];
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; }
        [Required]
        private string DescripcionAnomalia { set; get; }
        [Required]
        private string FechaReporteAnomalia { set; get; }
        private string FotoAnomalia { set; get; }
        [Required]
        private string TipoAnomalia { set; get; }
        [Required]
        private string AsuntoAnomalia { set; get; }

        [Required]
        [ForeignKey("Id_residente")]
        private Residente Residente { get; }
        private ICollection<String> Estados { set; get; }


    }


}