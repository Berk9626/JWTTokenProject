using Berk.JwtApp.Back.Core.Application.DTO;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest: IRequest<List<ProductListDto>> //listdto aslında bizim resultımız
    {
    }
}
