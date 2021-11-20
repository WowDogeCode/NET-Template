using Business.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IRepository<User> _repository;

        public UserManager(IRepository<User> repository) => _repository = repository;

        private List<User> _users = new List<User> {
            new User { Id=1, Name="Mike", UserName="Mike_32", Password = "1234", Surname = "Lead"},
            new User { Id=2, Name="Josef", UserName="Josefff", Password = "1357", Surname = "Tourne"}
        };

        public User Authenticate(string userName, string password)
        {
            //var result = _repository.GetAll().SingleOrDefault(user => user.UserName == userName && user.Password == password);
            var user = _users.SingleOrDefault(user => user.UserName == userName && user.Password == password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TempSecretKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;

            return user;
        }
    }
}
