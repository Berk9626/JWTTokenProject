using Berk.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Domain;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;
        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var deletedCategory = await _repository.GetByIdAsync(request.Id);
            if (deletedCategory != null)
            {
                await _repository.DeleteAsync(deletedCategory);
            }
            return Unit.Value;
            

        }
    }
}
