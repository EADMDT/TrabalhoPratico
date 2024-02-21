using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNet8VStudio.Model;
using RestAspNet8VStudio.Services;

namespace RestAspNet8VStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userService.FindByID(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            return Ok(_userService.Create(user));
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (user == null) return BadRequest();
            return Ok(_userService.Update(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _userService.Delete(id);
            return NoContent();
        }

    }
}
