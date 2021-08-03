using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Domain.Viewmodels;
using CakeShop.Infrastructure.EF;
using CakeShop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinmanager;
        private readonly RoleManager<Role> _rolemanager;
        private readonly IConfiguration _config;
        public UserRepository(
            UserManager<User> usermanager,
            SignInManager<User> signinmanager,
            RoleManager<Role>rolemanager,
            IConfiguration config, 
            CakeShopDbContext context):base(context) {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _rolemanager = rolemanager;
            _config = config;
        }
        public async Task<string> Authenticate(LoginInfo logininfo)
        {
            var user = await _usermanager.FindByNameAsync(logininfo.UserName);
            if (user != null)
            {
                var result = await _signinmanager.PasswordSignInAsync(user, logininfo.Password, logininfo.RememberMe, true);
                if (result.Succeeded)
                {
                    var role = await _usermanager.GetRolesAsync(user);
                    //IEnumerable<Claim> claims = new Claim[] {
                    //    new Claim("email",user.Email),
                    //    new Claim("name",user.FirstName),
                    //    new Claim("role",role.FirstOrDefault())
                    //};
                    //Generate JSONWebToken
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                      _config["Jwt:Issuer"],
                      null,
                      expires: DateTime.Now.AddMinutes(120),
                      signingCredentials: credentials);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Register(RegisterInfo registerinfo)
        {
            var user = new User()
            {
                FirstName = registerinfo.FirstName,
                LastName = registerinfo.LastName,
                Adress = registerinfo.Adress,
                PhoneNumber = registerinfo.PhoneNumber,
                Email = registerinfo.Email,
                UserName = registerinfo.UserName,
                Dob = registerinfo.Dob,              
            };
            var result = await _usermanager.CreateAsync(user, registerinfo.Password);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
