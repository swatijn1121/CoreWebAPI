using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreWebApi.Models; 
using CoreWebApi.Context;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace corewebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly MyDbContext _dc;
        private IConfiguration _configuration;
        public AccountController(MyDbContext dc,IConfiguration configuration)
        {
            _dc = dc;
            _configuration = configuration;   
        }
        [HttpPost]
        public IActionResult Login(UserAuth userauth)
        {
            if(userauth == null)
            {
                return BadRequest(); // 400
            }
            var result = _dc.UserAuths
            .Where(x => x.UserName == userauth.UserName && x.Password == userauth.Password)
            .FirstOrDefault();
            if (result == null)
            {
                return NotFound(); // 404
            }

            var Claims = new[]{
                new Claim(userauth.UserName,result.UserName)
            };

            string secureKey = _configuration.GetValue<string>("JWTSecuritySettings:SecureKey");

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var signingKey = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    claims: Claims,
                    issuer: "someone",
                    audience: "readers",
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signingKey
                );
            string mostSecureKey = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(mostSecureKey);
        }
    }


}