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
        public int Id { get; }
        [Required(ErrorMessage = "Por favor ingresa la descripcion de la anomalia")]
        public string DescripcionAnomalia { set; get; }
        [Required(ErrorMessage = "Por favor ingresa la fecha de la anomalia ")]
        public string FechaReporteAnomalia { set; get; }
        public string FotoAnomalia { set; get; }
        [Required(ErrorMessage = "Por favor ingresa el tipo de anomalia")]
        public string TipoAnomalia { set; get; }
        [Required(ErrorMessage = "Por favor ingresa el asunto de anomalia")]
        public string AsuntoAnomalia { set; get; }

        [Required(ErrorMessage = "Por favor inresa el id del residente")]
        [ForeignKey("Id_residente")]
        public Residente Residente { get; }
        public ICollection<String> Estados { set; get; }


    }


}