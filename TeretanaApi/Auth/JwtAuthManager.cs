using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace TeretanaApi.Auth
{
    public class JwtAuthManager
    {
        private readonly string _key;
        public JwtAuthManager(string key)
        {
            this._key = key;
        }

        public string Authenticate(string userName, string password, string userType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userType)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            /*
            JwtToken tokenRes = new JwtToken
            {
                Token = tokenHandler.WriteToken(token),
                ExpiresOn = String.Format("{0:dd-MM-yyyy hh:mm:ss}", (DateTime)tokenDescriptor.Expires)
            };
            return tokenRes;
            */
            return tokenHandler.WriteToken(token);

        }


        public void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash,byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
