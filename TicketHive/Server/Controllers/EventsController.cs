using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Repo;
using TicketHive.Shared.Models;


namespace TicketHive.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepo repo;
        public EventsController(IEventsRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<EventModel>?>> GetEventsAsync()
        {
            var result = await repo.GetEventsAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel?>> GetEventById(int id)
        {
            var result = await repo.GetEventByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventModel model)
        {
            var result = await repo.PostEventAsync(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EventModel model)
        {
            var result = await repo.PutEventAsync(id, model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await repo.DeleteEventAsync(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
