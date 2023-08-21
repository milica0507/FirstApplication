using Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Aplikacija.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Aplikacija.Services
{
    public class UsersService
    {
        private ApplicationDbContext _context;
        private IConfiguration _configuration;

        public UsersService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
          
        }


        public string RegisterUser(UserVM user)
        {
            CreatePasswordHash(user.Password, out byte[] passHash, out byte[] passSalt);
            var str = Convert.ToBase64String(passHash);
            var pom = _context.Users.Where(x => x.Username == user.Username).FirstOrDefault();
            if (pom != null)
            {
                return  "User already exists";
            }

            var _user = new User();
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Username = user.Username;
            _user.NumberPhone = user.NumberPhone;
            _user.PasswordHash = Convert.ToBase64String(passHash);
            _user.PasswordSalt = Convert.ToBase64String(passSalt);
            _context.Users.Add(_user);
            _context.SaveChanges();

            return "User registered successfully";

        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string pass, string passHash, string passSalt)
        {
            using (var hmac = new HMACSHA512(Convert.FromBase64String(passSalt)))
            {
                var ComputeHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass)));
                if (ComputeHash == passHash)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string LogIn(string username,string pass)
        {
            var _user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            if (!VerifyPasswordHash(pass, _user.PasswordHash, _user.PasswordSalt)) 
            {
                return "Invalid password";
            }
            string token = CreateClaimUser(_user);
            _user.Token = token;
            _context.SaveChanges();
            return token;

        }

        public void LogOut(string id)
        {
            var _user = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (_user != null)
            {
                _user.Token = null;
                _context.SaveChanges();
            }
        }


        private string CreateToken(List<Claim> claims)
        {
            var nesto = _configuration.GetSection("AppSettings:Token").Value;
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private string CreateClaimUser(User user)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, "korisnik")
        };
            return CreateToken(claims);
        }


        public void DeleteUser(string id)
        {
            var user = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User UpdateUsername(string id,string newUsername)
        {
            var _user = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if(_user != null)
            {
                _user.Username = newUsername;

                _context.SaveChanges();
            }

            return _user;
        }

        public object GetUserByUsername(string username)
        {
            var _user = _context.Users
                .Where(x => x.Username == username)
                .Select(x=>new
                {
                    FirstName=x.FirstName,
                    LastName=x.LastName,
                    NumberPhone=x.NumberPhone
                })
                .FirstOrDefault();
            return _user;
        }
    }
}
