using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsRoles.Roles;

namespace ModelsUser.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_User { get;set; }

        [Required]
        [EmailAddress(ErrorMessage = "Username invalido")]
        public string Username { set; get; }

        [Required(ErrorMessage = "No has ingresado el password")]
        public string Password { set; get; }

        public ICollection<Roles> Roles { set; get; }

        public User(string Username, string Password, ICollection<Roles> Roles)
        {
            this.Username = Username;
            this.Password = Password;
            this.Roles = Roles ?? new HashSet<Roles>();
        }

        public User()
        {
        }
    }
}