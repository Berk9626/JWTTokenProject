using Berk.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Domain;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct =  await _repository.GetByIdAsync(request.Id);

            if (updatedProduct != null)
            {
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.Stock = request.Stock;
                updatedProduct.Name = request.Name;
                updatedProduct.Price = request.Price;
                await _repository.UpdateAsync(updatedProduct);
            }


            return Unit.Value;
            
            
        }
    }
}
