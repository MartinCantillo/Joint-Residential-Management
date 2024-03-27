using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsUser.Usern
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_User { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Username invalido")]
        public string Username { set; get; }

        [Required(ErrorMessage = "No has ingresado el password")]
        public string Password { set; get; }

        public string Roles { set; get; }
        [Required]
        public bool IsActivo { get; set; } //Si esta activo el usuario

        public User(string Username, string Password, string Roles, bool IsActivo)
        {
            this.Username = Username;
            this.Password = Password;
            this.Roles = Roles;
            this.IsActivo = IsActivo;

        }

        public User()
        {
        }
    }
}