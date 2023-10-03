using CCA_BE.Context;
using CCA_BE.Excel;
using CCA_BE.Helpers;
using CCA_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace CCA_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CCADbContext _context;
        public UserController(CCADbContext ccaDbContext)
        {
            _context = ccaDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObject)
        {
            if (userObject == null)
            {
                return BadRequest();
            }

            var user = await _context.Users.FirstOrDefaultAsync(x=>x.ID == userObject.ID);
            if (user == null)
            {
                return NotFound(new {Message="User Not Found!"});
            }

            if (!PasswordHasher.VerifyPassword(userObject.Password, user.Password))
            {
                return BadRequest(new { Message = "Password incorreta" });
            }

            user.Token = CreateJWT(user);

            return Ok(new
            {
                user.Token,
                Message = "Login Success!"
            }); ;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userObject)
        {
            if(userObject == null)
            {
                return BadRequest();
            }
            //check Id
            if(await CheckIdExistsAsync(userObject.ID))
                return BadRequest(new {Message="Esse Id já existe"});

            //check email
            if (await CheckEmailExistsAsync(userObject.Email))
                return BadRequest(new { Message = "Esse email já existe" });
            //check password
            var pass = Checkpassword(userObject.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new {Message = pass.ToString()});

            userObject.Password = PasswordHasher.HashPassword(userObject.Password);
            if(userObject.Role == null)
                userObject.Role = "Aluno";
            userObject.Token = "";
            await _context.Users.AddAsync(userObject);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message="Utilizador registado"
            });
        }


        private  Task<bool> CheckIdExistsAsync(string id)
           => _context.Users.AnyAsync(x => x.ID == id);
        private Task<bool> CheckEmailExistsAsync(string email)
           => _context.Users.AnyAsync(x => x.Email == email);

        private string Checkpassword( string password)
        {
            StringBuilder sb= new StringBuilder();
            if(password.Length < 8)
                sb.Append("A password tem de conter pelo menos 8 caracteres" + Environment.NewLine);
            
            if(!(Regex.IsMatch(password,"[a-z]") && Regex.IsMatch(password,"[A-Z]") &&  Regex.IsMatch(password,"[0-9]")))
                sb.Append("A password tem de ser Alfanumérica" + Environment.NewLine);


            return sb.ToString();

        }

        private string CreateJWT(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("supersecretKey123");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.ID),
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }




    }
}
