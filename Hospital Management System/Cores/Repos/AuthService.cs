using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;
using Hospital_Management_System.Cores.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital_Management_System.Cores.Repos
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> usermanager;

        public AuthService(UserManager<ApplicationUser> usermanager)
        {
            this.usermanager = usermanager;
        }

        public async Task<AuthModel> Register(RegisterModelDto model)
        {
            if(await usermanager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel { Message = "This email is exist" };
            }

            if (await usermanager.FindByNameAsync(model.UserName) is not null)
            {
                return new AuthModel { Message = "This UserName is exist" };
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password,
            };

            var result = await usermanager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new AuthModel { Message = "Error" };
            }

            var role = await usermanager.AddToRoleAsync(user, "PATIENT");

            var jwt = await CreateToken(user);
            return new AuthModel
            {
                Email = user.Email,
                Name = user.UserName,
                IsAuthentication = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                ExpireOn = jwt.ValidTo
            };
        }
        public async Task<AuthModel> Login(LoginModelDto model)
        {
            var user = await usermanager.FindByNameAsync(model.Username);
            if (user == null || !await usermanager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthModel { Message = "UserName or password is incorrect" };
            }

            var jwt = await CreateToken(user);
            return new AuthModel
            {
                Email = user.Email,
                Name = user.UserName,
                IsAuthentication = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                ExpireOn = jwt.ValidTo,
            };
        }


        private async Task<JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            var roles = await usermanager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }

            var securitykey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes
                ("jdsfhlsdhKJLJGKUYRTYKIOPOGUYDTRdkdkdkHGFSSZSAQQWROPOJLKJNNMVNBCVBXDSZDTREEVVAAiikSYHOIESZ"));

            var signincred = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                  issuer: "https://localhost:44377",
                  audience: "https://localhost:4200",
                  claims: claims,
                  expires: DateTime.UtcNow.AddMinutes(15),
                  signingCredentials : signincred
                );

            return token;
        }
    }
}
