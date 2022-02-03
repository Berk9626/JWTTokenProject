using Berk.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Berk.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Berk.JwtApp.Back.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Berk.JwtApp.Back.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn( CheckUserQueryRequest request)
        {
            var userDto = await _mediator.Send(request);
            if (userDto.IsExist)
            {
                var token = JwtTokenGenerator.GenerateToken(userDto);
                //handler.WriteToken()
                return Created("", token);
            }
            return BadRequest("UserName veya Password hatalı!");
        }



    }
}
