namespace Common.Dto.User
{
    public class RefreshTokenDto
    {
        public string token_type { get; set; } = string.Empty;
        public string access_token { get; set; } = string.Empty;
        public DateTime? expires_at { get; set; }
    }
}
