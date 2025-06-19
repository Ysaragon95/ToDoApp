namespace ToDo.Application.DTOs.Security
{
    public class AuthResponse
    {
        public int IdUser { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
