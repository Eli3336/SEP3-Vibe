//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
using Shared;
using Shared.DTOs;
using Shop.Services;

namespace Shop.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration config;
    private readonly IAuthService authService;

    public AuthController(IConfiguration config, IAuthService authService)
    {
        this.config = config;
        this.authService = authService;
    }

    [HttpPost, Route("register")]
    public async Task<ActionResult> Register([FromBody] Customer customer)
    {
        await authService.RegisterCustomer(customer);
        return Ok();
    }

    [HttpPost, Route("login")]
    public async Task<ActionResult> Login([FromBody] CustomerLoginDto customerLoginDto)
    {
        try
        {
            Customer customer = await authService.ValidateCustomer(customerLoginDto.UserName, customerLoginDto.Password);
            string token = GenerateJwt(customer);
        
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    private string GenerateJwt(Customer customer)
    {
        List<Claim> claims = GenerateClaims(customer);
        
        //SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
       // SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        
       // JwtHeader header = new JwtHeader(signIn);
        
       // JwtPayload payload = new JwtPayload(
           // config["Jwt:Issuer"],
          //  config["Jwt:Audience"],
          //  claims, 
          //  null,
          //  DateTime.UtcNow.AddMinutes(60));
        
       // JwtSecurityToken token = new JwtSecurityToken(header, payload);
        
       // string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
      //  return serializedToken;
      return "";
    }

    private List<Claim> GenerateClaims(Customer customer)
    {
        var claims = new[]
        {
          //  new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
           // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
           // new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, customer.username)
        };
        return claims.ToList();
    }
}