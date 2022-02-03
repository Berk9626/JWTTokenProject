using Berk.JwtApp.Back.Core.Application.DTO;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest: IRequest<ProductListDto>
    {
        public int Id { get; set; }
        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
