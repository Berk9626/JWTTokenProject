using Berk.JwtApp.Back.Core.Application.DTO;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
