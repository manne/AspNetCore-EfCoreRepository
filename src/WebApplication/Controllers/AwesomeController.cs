using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Manne.EfCore.AwesomeModule;
using Manne.EfCore.AwesomeModule.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AwesomeController : ControllerBase
    {
        private readonly ILogger<AwesomeController> _logger;

        public AwesomeController(ILogger<AwesomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async ValueTask<IEnumerable<Awesome>> GetAllAsync([FromServices] IReadableAwesomeDbContext readableDbContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("get all awesomes");
            var entities = await readableDbContext.Awesomes.ToListAsync(cancellationToken);
            return entities;
        }

        [HttpGet("{id}")]
        public async ValueTask<Awesome> GetAsync(int id, [FromServices] IReadableAwesomeDbContext readableDbContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("get all awesomes");
            var entities = await readableDbContext.Awesomes.FirstAsync(a => a.Id == id, cancellationToken);
            return entities;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAwesomeRequest request, [FromServices] IWriteableAwesomeDbContext writeableDbContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("create awesome");
            var instanceToCreate = new Awesome
            {
                Bla = request.Bla,
                Blub = request.Blub
            };
            writeableDbContext.Add(instanceToCreate);
            await writeableDbContext.SaveChangesAsync(cancellationToken);
            return CreatedAtAction("Get", new { id = instanceToCreate.Id }, instanceToCreate);
        }
    }
}
