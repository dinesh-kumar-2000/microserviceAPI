using AutoMapper;
using Ecommerce.IdentityService.Application.DTOs.Role;
using Ecommerce.IdentityService.Application.Features.Role.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RoleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            var command = _mapper.Map<CreateRoleCommand>(dto);
            var roleid = await _mediator.Send(command);
            return Created();
        }
    }
}
