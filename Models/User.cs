using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUser.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id_User {  get; }

        [Required]
        [EmailAddress(ErrorMessage = "Username invalido")]
        private string Username { set; get; }

        [Required]
        private string Password { set; get; }

        private ICollection<String> Roles { set; get; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
            Roles = new HashSet<String>();
        }
    }
}