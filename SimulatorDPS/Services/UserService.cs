using Microsoft.IdentityModel.Tokens;

using SimulatorDPS.Data;
using SimulatorDPS.DataBaseEF;
using SimulatorDPS.Models;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimulatorDPS.Services
{
    public class UserService
    {
        private ApplicationContext _dbContext;
        public UserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel GetUserByLogin(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);
            return new UserModel
            {
                Id = user.Id,
                UserName = username
            };
        }

        public UserModel GetUserByLoginPass(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            return new UserModel
            {
                Id = user.Id,
                UserName = username
            };
        }
        public UserDTO GetUserLoginPassBasicAuth(HttpRequest request)
        {
            var userDTO = new UserDTO();
            string authHeader = request.Headers["Authorization"].ToString();
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUserNamePass = authHeader.Replace("Basic ", "");
                var encoding = Encoding.GetEncoding("iso-8859-1");

                string[] namePassArray = encoding.GetString(Convert.FromBase64String(encodedUserNamePass)).Split(':');
                userDTO.Login = namePassArray[0];
                userDTO.Password = namePassArray[1];
            }
            return userDTO;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = GetUserByLoginPass(username, password);

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "Token");

            return claimsIdentity;
        }

        public UserModel CreateUser(string username, string password)
        {
            var user = new User
            {
                UserName = username,
                Password = password
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
            };
        }
        
        public UserModel UpdateUser(int id, string name)
        {
            var userToUpdate = _dbContext.Users.FirstOrDefault(u =>  u.Id == id);
            
            if (userToUpdate != null)
            {
                userToUpdate.UserName = name;
            }

            return new UserModel
            {
                Id = id,
                UserName = name,
            };
        }

        public UserModel DeleteUser(int id, string name)
        {
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (currentUser != null)
            {
                _dbContext.Users.Remove(currentUser);
                _dbContext.SaveChanges();
            }

            return new UserModel
            {
                Id = id,
                UserName = name
            };
        }
        public TokenModel CreateJWToken(ClaimsIdentity identity)
        {
            var claim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var username = claim.Value;
            var user = GetUserByLogin(username);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            var lifeTime = 5;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(lifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var tokenModel = new TokenModel
            {
                AccessToken = encodedJwt,
                LifeTime = lifeTime,
                UserId = user.Id,
                UserLogin = user.UserName,
            };

            return tokenModel;
        }
    }
}
