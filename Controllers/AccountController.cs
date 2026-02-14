using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using TodoList.Data;
using TodoList.DTOs;
using TodoList.Extensions;
using TodoList.Models;
using TodoList.Services;
using TodoList.ViewModels;

namespace TodoList.Controllers {
    [ApiController]
    public class AccountController : ControllerBase {

        [HttpPost("v1/login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginDto dto,
            [FromServices] TokenService tokenService,
            [FromServices] ToDoListDataContext context) {

            if (!ModelState.IsValid) {
                return BadRequest(new ResultViewModel<List<string>>(ModelState.GetErrors()));
            }

            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user == null) {
                return BadRequest(new ResultViewModel<string>("Ususario ou senha invalido"));
            }

            if (!PasswordHasher.Verify(user.PasswordHash, dto.Password)) {
                return BadRequest(new ResultViewModel<string>("Ususario ou senha invalido"));
            }

            var token = tokenService.GenerateToken(user);

            return Ok(new ResultViewModel<string>(token, null));
        }
    }
}
