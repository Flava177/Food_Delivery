using Contracts;
using Entities.Models;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private User? _user;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GeoCoordinate _geoCoordinate;
        private readonly HttpClient _httpClient;

        public AuthenticationService(ILoggerManager logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _geoCoordinate = new GeoCoordinate();
            _httpClient = httpClient;

        }

        private async Task<string> GetIPAddress()
        {
            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }
            return "";
        }

        public async Task<string> GetGeoInfo()
        {
            var ipAddress = await GetIPAddress();
            var response = await _httpClient.GetAsync($"http://api.ipstack.com/" + ipAddress +
                "?access_key=5e057ff31ee468ce88a74e8f2fd91c1a");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            return null;
        }


        //Register Admin User
        public async Task<IdentityResult> RegisterAdminUser(UserForRegistrationDto userForRegistration)
        {

            var geoInfo = await GetGeoInfo(); // Invoke GetGeoInfo method to retrieve the JSON response
            var geoInfoObject = JObject.Parse(geoInfo); // Parse the JSON response
            var latitude = (geoInfoObject["latitude"]?.ToString()) ?? "0.0"; // Get the latitude value from the parsed JSON
            var longitude = geoInfoObject["longitude"]?.ToString() ?? "0.0";// Get the longitude value from the parsed JSON


            var user = new User
            {
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                UserName = userForRegistration.UserName,
                Email = userForRegistration.Email,
                Latitude = double.Parse(latitude),
                Longitude = double.Parse(longitude),
                PasswordHash = userForRegistration.Password,
                PhoneNumber = userForRegistration.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (result.Succeeded)

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            return result;
        }



        //Register User as Customer
        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {

            var geoInfo = await GetGeoInfo(); // Invoke GetGeoInfo method to retrieve the JSON response
            var geoInfoObject = JObject.Parse(geoInfo); // Parse the JSON response
            var latitude = (geoInfoObject["latitude"]?.ToString()) ?? "0.0"; // Get the latitude value from the parsed JSON
            var longitude = geoInfoObject["longitude"]?.ToString() ?? "0.0";// Get the longitude value from the parsed JSON

            var user = new User
            {
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                UserName = userForRegistration.UserName,
                Email = userForRegistration.Email,
                Latitude = double.Parse(latitude),
                Longitude = double.Parse(longitude),
                PasswordHash = userForRegistration.Password,
                PhoneNumber = userForRegistration.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (result.Succeeded)

                if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

            if (await _roleManager.RoleExistsAsync(UserRoles.Customer))
                await _userManager.AddToRoleAsync(user, UserRoles.Customer);

            return result;
        }

        //fetch the user from the database and check whether they exist and if the password matches
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = _user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password);
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            return result;
        }


        //create token
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }


        //return the secret key
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:key"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        //create list of claims with the user name
        private async Task<List<Claim>> GetClaims() 
        {
            var claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Name, _user.UserName)
            }; 

            var roles = await _userManager.GetRolesAsync(_user); 
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            } 
            return claims; 
        }


        //create an object of the JwtSecurityToken
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims) 
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }


}