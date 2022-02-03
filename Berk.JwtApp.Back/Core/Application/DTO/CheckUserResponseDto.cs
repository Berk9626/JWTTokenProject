namespace Berk.JwtApp.Back.Core.Application.DTO
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsExist  { get; set; }
    }
}
