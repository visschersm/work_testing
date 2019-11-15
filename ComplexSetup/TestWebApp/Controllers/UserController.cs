
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;

namespace TestWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ViewModel.User.Create create)
        {
            var result = await _userService.CreateAsync<ViewModel.User.Full>(create);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _userService.GetAsync<ViewModel.User.List>();

            return Ok(result);
        }
    }
}