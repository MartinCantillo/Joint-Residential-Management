using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsRoles.Roles
{
    public class Roles
    {
        public Roles()
        {
        }
        public Roles(string nombre)
        {
            this.nombre = nombre;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Roles { get;set; }
        [Required]
        public string nombre { get; set; }


    }

}