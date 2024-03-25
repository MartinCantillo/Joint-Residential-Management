using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUser.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_User { get; }

        [Required]
        [EmailAddress(ErrorMessage = "Username invalido")]
        public string Username { set; get; }

        [Required(ErrorMessage = "No has ingresado el password")]
        public string Password { set; get; }

        public ICollection<String> Roles { set; get; }

        public User(string Username, string Password, ICollection<string> Roles)
        {
            this.Username = Username;
            this.Password = Password;
            this.Roles = Roles ?? new HashSet<string>();
        }
    }
}