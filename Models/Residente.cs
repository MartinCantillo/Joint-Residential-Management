using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsUser.User;

namespace ModelResidente.Residente
{

    public class Residente
    {
        public Residente()
        {
        }

        public Residente(String Nombre_residente, String Num_apartamento, String Num_telefono, User Usuario)
        {
            this.Nombre_residente = Nombre_residente;
            this.Num_apartamento = Num_apartamento;
            this.Num_telefono = Num_telefono;
            this.Usuario = Usuario;
        }

        [Key] //primarykey
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//autoincrementable
        public int Id_residente { get;set; }
        [Required(ErrorMessage = "Por favor ingresa el nombre del residente")]
        public String Nombre_residente { set; get; }
        [Required(ErrorMessage = "Por favor ingresa numero de apartamento")]
        public String Num_apartamento { get; set; }

        public String Num_telefono { get; set; }
        [Required(ErrorMessage = "Por favor ingresa el usuario")]

        [ForeignKey("Id_User")]
        public User Usuario { set; get; }





    }
}