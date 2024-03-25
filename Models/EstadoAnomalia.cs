using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsEstadoAnomalia.EstadoAnomalia
{
    public class EstadoAnomalia
    {
        public EstadoAnomalia()
        {
        }
        public EstadoAnomalia(string Nombre_Estado, DateTime fechaEstado)
        {
            this.Nombre_Estado = Nombre_Estado;
            this.fechaEstado = fechaEstado;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;set; }
        [Required]
        public string Nombre_Estado { get; set; }
        [Required]
        public DateTime fechaEstado { set; get; }

    }

}