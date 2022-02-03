using Berk.JwtApp.Back.Core.Application.DTO;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest: IRequest<CategoryListDto>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
