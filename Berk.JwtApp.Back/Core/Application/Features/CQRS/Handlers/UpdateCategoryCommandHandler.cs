using AutoMapper;
using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Domain;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedCategory = await _repository.GetByIdAsync(request.Id);
            if (updatedCategory != null)
            {
                updatedCategory.Definition = request.Definition;
                await _repository.UpdateAsync(updatedCategory);
            }
          
            return Unit.Value;


        }
    }
}
