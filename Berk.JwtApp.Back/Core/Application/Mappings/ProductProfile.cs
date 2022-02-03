using AutoMapper;
using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Domain;

namespace Berk.JwtApp.Back.Core.Application.Mappings
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product,ProductListDto>().ReverseMap();
        }
    }
}
