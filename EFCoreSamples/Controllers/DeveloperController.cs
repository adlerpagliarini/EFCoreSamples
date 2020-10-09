using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EFCoreSamples.Infrastructure;
using System.Linq;

namespace EFCoreSamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger<DeveloperController> _logger;

        public DeveloperController(ILogger<DeveloperController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _databaseContext
                .Developer
                    .Include(e => e.Motivation)
                    .Include(e => e.TasksToDo)
                            .ThenInclude(e => e.Skills)
                .ToListAsync();

            response.ForEach(e => e.HowIAm());
            return Ok(response);
        }

        [HttpGet("Front-End")]
        public async Task<IActionResult> GetFrontEnd()
        {
            var response = await _databaseContext
                .FrontEndDeveloper
                    .Include(e => e.Motivation)
                    .Include(e => e.TasksToDo)
                        .ThenInclude(e => e.Skills)
                .ToListAsync();

            response.ForEach(e => e.HowIAm());
            return Ok(response);
        }

        [HttpGet("Back-End")]
        public async Task<IActionResult> GetBackEnd()
        {
            var response = await _databaseContext
                .BackEndDeveloper
                    .Include(e => e.Motivation)
                    .Include(e => e.TasksToDo)
                        .ThenInclude(e => e.Skills)
                .ToListAsync();

            response.ForEach(e => e.HowIAm());
            return Ok(response);
        }

        [HttpGet("Full-Stack")]
        public async Task<IActionResult> GetFullStack()
        {
            var response = await _databaseContext
                .FullStackDeveloper
                    .Include(e => e.Motivation)
                    .Include(e => e.TasksToDo)
                        .ThenInclude(e => e.Skills)
                .ToListAsync();

            response.ForEach(e => e.HowIAm());
            return Ok(response);
        }

        [HttpGet("Explicit-Loading")]
        public IActionResult GetExplicitLoading()
        {
            var developers = _databaseContext.Developer;

            foreach (var developer in developers)
            {
                _databaseContext.Entry(developer).Reference(e => e.Motivation).Load();
                _databaseContext.Entry(developer).Collection(e => e.TasksToDo).Load();
                foreach (var taskToDo in developer.TasksToDo)
                {
                    _databaseContext.Entry(taskToDo).Collection(e => e.Skills).Load();
                }
            }
            developers.ToList().ForEach(e => e.HowIAm());
            return Ok(developers);
        }

        [HttpGet("QueryString")]
        public IActionResult GetQueryString()
        {
            var response = _databaseContext
                .Developer
                    .Include(e => e.Motivation)
                    .Include(e => e.TasksToDo)
                            .ThenInclude(e => e.Skills)
                .ToQueryString();

            return Ok(response);
        }
    }
}
