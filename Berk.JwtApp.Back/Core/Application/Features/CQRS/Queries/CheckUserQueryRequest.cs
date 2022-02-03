using Berk.JwtApp.Back.Core.Application.DTO;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
    }
}
