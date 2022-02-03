using AutoMapper;
using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Domain;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public GetProductQueryHandler(IRepository<Product> repository,  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByFilter(x => x.Id == request.Id);

            return  _mapper.Map<ProductListDto>(product);
        }
    }
}
