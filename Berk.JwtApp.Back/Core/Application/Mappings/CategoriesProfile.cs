using AutoMapper;
using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Domain;

namespace Berk.JwtApp.Back.Core.Application.Mappings
{
    public class CategoriesProfile: Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category,CategoryListDto>().ReverseMap();
        }
    }
}
