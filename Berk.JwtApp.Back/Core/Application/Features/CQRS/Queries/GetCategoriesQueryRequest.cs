using Berk.JwtApp.Back.Core.Application.DTO;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest: IRequest<List<CategoryListDto>>
    {
    }
}
