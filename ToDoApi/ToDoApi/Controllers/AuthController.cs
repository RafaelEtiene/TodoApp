using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using ToDoApi.Model;

namespace ToDoApi.Controllers
{
    public class AuthController : ControllerBase
    {
        public static CreateUser user = new CreateUser();

        [HttpPost("Register")]
        public async Task<ActionResult<Login>> Register(CreateUser request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            user.p
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
