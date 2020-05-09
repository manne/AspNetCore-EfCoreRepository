using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly AwesomeContext _awesomeContext;

        public AwesomeController(ILogger<AwesomeController> logger, AwesomeContext awesomeContext)
        {
            _logger = logger;
            _awesomeContext = awesomeContext;
        }

        [HttpGet]
        public async ValueTask<IEnumerable<Awesome>> GetAllAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("get all awesomes");
            var entities = await _awesomeContext.Awesome.AsNoTracking().ToListAsync(cancellationToken);
            return entities;
        }
    }
}
