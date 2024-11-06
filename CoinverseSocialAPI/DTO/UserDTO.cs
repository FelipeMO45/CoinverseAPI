namespace CoinverseSocialAPI.DTO
{
    public class UserDto
    {
        public int PkUser { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Biography { get; set; }
        public string? Website { get; set; }
        public DateTime? Date { get; set; }
        public string? Photo { get; set; }
        public bool IsOnline { get; set; }
    }

}
