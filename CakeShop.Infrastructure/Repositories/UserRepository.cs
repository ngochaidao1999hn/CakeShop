using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.UserDtos;
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
                    var claims = new Claim[] {
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Surname,user.LastName),
                        new Claim(ClaimTypes.DateOfBirth,user.Dob.ToString()),
                        new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                        new Claim(ClaimTypes.StreetAddress,user.Adress),
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                       
                        //new Claim(ClaimTypes.Role,role.FirstOrDefault())
                    };                   
                    //Generate JSONWebToken
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                      _config["Jwt:Issuer"],
                      claims,
                      expires: DateTime.Now.AddHours(2),
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
        public async Task<string> Register(RegisterInfo registerinfo)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
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
                return "Success";
            }
            else
            {
                return "False";
            }
        }
    }
}
