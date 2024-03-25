namespace RepositoriesIAuthenticationUser.IAuthenticationUser
{
    public interface IAuthenticationUser{
        
        public string GenerateToken(int id,string nombre,ICollection<string>roles);
        public bool ValidateToken(string token);

    }
    
}