using ClientBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClientBackend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AuthenticationController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Register([FromBody] AppUser registerUser)
        {
            var exists = _userManager.FindByEmailAsync(registerUser.Email);
            if (exists != null)
            {
                return new NotFoundResult();
            }
            var res = _userManager.CreateAsync(registerUser);
            if (res.IsCompletedSuccessfully)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


        [HttpGet("{email}/{password}")]
        public IActionResult Login(string email, string password)
        {
            var res = _userManager.FindByEmailAsync(email).Result;
            if (res != null && _userManager.CheckPasswordAsync(res, password).Result)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, res.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var userRoles = _userManager.GetRolesAsync(res).Result;
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var jwtToken = GetToken(authClaims);
                var response = new { token = new JwtSecurityTokenHandler().WriteToken(jwtToken), expiration = jwtToken.ValidTo };
                return new OkObjectResult(response);

                }
            return new UnauthorizedResult();
        }
    }
}
