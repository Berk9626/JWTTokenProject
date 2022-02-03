using AutoMapper;
using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Domain;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByFilter(x=>x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(category);


        }
    }
}
