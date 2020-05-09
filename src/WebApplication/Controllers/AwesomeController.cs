using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Manne.EfCore.AwesomeModule;
using Manne.EfCore.AwesomeModule.Contracts;
using Manne.EfCore.AwesomeModule.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AwesomeController : ControllerBase
    {
        private readonly ILogger<AwesomeController> _logger;
        private readonly IMediator _mediator;

        public AwesomeController(ILogger<AwesomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IEnumerable<Awesome>> GetAllAsync([FromQuery] GetAllQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("get all awesomes");
            var entities = await _mediator.Send(query, cancellationToken);
            return entities;
        }

        [HttpGet("{id}")]
        public async ValueTask<Awesome> GetAsync(GetSingleQuery query, [FromServices] IReadableAwesomeDbContext readableDbContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("get single awesomes");
            var entity = await _mediator.Send(query, cancellationToken);
            return entity;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAwesomeCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("create awesome");
            var entity = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }
    }
}
