
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;

namespace TestWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> CreateAsync(ViewModel.User.Create toCreate)
        {
            return Ok(_userService.CreateAsync<ViewModel.User.Full>(toCreate));
        }

        public async Task<IActionResult> GetAsync()
        {
            return Ok(_userService.GetAsync<ViewModel.User.List>());
        }
    }
}