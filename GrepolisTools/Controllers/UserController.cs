using GrepolisTools.Data;
using GrepolisTools.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrepolisTools.Models;
using GrepolisTools.Data;

namespace GrepolisTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto userDto)
        {
            var userExists = await _context.Users.AnyAsync(x => x.Username == userDto.Username || x.Email == userDto.Email);

            if (userExists)
            {
                return BadRequest("El nombre de usuario o correo electrónico ya existe");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var user = new User
            {
                Username = userDto.Username,
                Name = userDto.Name,
                Password = hashedPassword,
                Email = userDto.Email,
                RoleId = userDto.RoleId,
                AllianceId = userDto.AllianceId,
                StateId = userDto.StateId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // POST: api/User/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginDto.Username);

            if (user == null)
            {
                return Unauthorized("Nombre de usuario inválido");
            }

            var passwordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);

            if (!passwordValid)
            {
                return Unauthorized("Contraseña incorrecta");
            }

            // Deberías generar y devolver un token JWT aquí
            // Por ahora, devolveremos una cadena de texto estática como marcador de posición
            return "Esto debería ser un token JWT";
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Username = userDto.Username;
            user.Name = userDto.Name;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            user.Email = userDto.Email;
            user.RoleId = userDto.RoleId;
            user.AllianceId = userDto.AllianceId;
            user.StateId = userDto.StateId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}