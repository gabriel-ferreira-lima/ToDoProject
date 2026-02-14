using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using System.Data.Common;
using TodoList.Data;
using TodoList.DTOs.UserDtos;
using TodoList.Extensions;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Controllers {
    [ApiController]
    public class UserController : ControllerBase {


        [HttpPost("v1/users")]
        public async Task<IActionResult> Post(
            [FromBody] PostUserDto dto,
            [FromServices] ToDoListDataContext context) {

            if (!ModelState.IsValid) {
                return BadRequest(new ResultViewModel<List<string>>(ModelState.GetErrors()));
            }

            try {

                dto.Password = PasswordHasher.Hash(dto.Password);

                var user = new User {
                    Name = dto.Name,
                    Email = dto.Email,
                    PasswordHash = dto.Password
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                }));
            }
            catch (DbException) {
                return BadRequest(new ResultViewModel<string>("02x01 Erro ao consultar o banco"));
            }
            catch (Exception) {
                return StatusCode(500, new ResultViewModel<string>("02x02 Erro interno de servidor"));
            }

        }
    }
}
