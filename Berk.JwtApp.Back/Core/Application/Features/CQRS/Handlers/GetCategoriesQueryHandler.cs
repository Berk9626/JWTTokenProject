using AutoMapper;
using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Domain;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
             var result =await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(result);

        }
    }
}
