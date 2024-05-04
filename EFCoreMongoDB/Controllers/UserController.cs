using Domain.Data;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EFCMContext _context;  

        public UserController(EFCMContext context)
        {
            _context = context; 
        }


        [HttpGet("GetUser")]
        public async Task<User> GetUser([FromQuery]string Id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == Id);
        }

        [HttpGet]
        public async Task<IQueryable<User>> Get()
        {
           return _context.Users.AsQueryable();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
