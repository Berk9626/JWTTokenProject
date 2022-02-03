using Berk.JwtApp.Back.Core.Application.DTO;
using Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Berk.JwtApp.Back.Core.Application.Interfaces;
using Berk.JwtApp.Back.Core.Domain;
using MediatR;

namespace Berk.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _appuserrepository;
        private readonly IRepository<AppRole> _approlerepository;

        public CheckUserQueryRequestHandler(IRepository<AppUser> repository, IRepository<AppRole> approlerepository)
        {
            _appuserrepository = repository;
            _approlerepository = approlerepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();

            var user = await _appuserrepository.GetByFilter(x=>x.UserName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;

                var role = await _approlerepository.GetByFilter(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;


            }

           


            return dto;
        }
    }
}
