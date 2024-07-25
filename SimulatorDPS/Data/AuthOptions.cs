using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace SimulatorDPS.Data
{
    public class AuthOptions
    {
        public const string ISSUER = "rmpprod";
        public const string AUDIENCE = "ReactClient";
        const string KEY = "mysupersecret_secretsecretsecretkey!321";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}