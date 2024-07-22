using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Persistence.Services;
using PDD.NET.Application.Auth;
using PDD.NET.Application.Auth.Request;
using PDD.NET.Application.Auth.Response;
using MediatR;
using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;
using System.Threading;
using PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;
using PDD.NET.Application.Features.Users.Queries.GetUser;
using PDD.NET.Domain.Entities;

namespace PDD.NET.WebApi.Controllers;

[ApiController]
//[Route("api/[controller]")]
[Route("api/authorization/manager")]
public class AuthController : ControllerBase
{
    // Identity package
    //private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtService _jwtService;
    private readonly IMediator _mediator;

    public AuthController( IJwtService jwtService, IMediator mediator)
    {
        //_userManager = userManager;
        _jwtService = jwtService;
        _mediator = mediator;
    }

/*    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDTO user)
    {
        if (ModelState.IsValid)
        {
            IdentityUser existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return BadRequest(new RegisterResponseDTO()
                {
                    Errors = new List<string>() { "Email already Registered" },
                    Success = false
                });
            }

            IdentityUser newUser = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.Username,
            };

            IdentityResult? created = await _userManager.CreateAsync(newUser, user.Password);
            if (created.Succeeded)
            {
                AuthResult authResult = await _jwtService.GenerateToken(newUser);
                //return a token
                return Ok(authResult);
            }
            else
            {
                return BadRequest(new RegisterResponseDTO()
                {
                    Errors = created.Errors.Select(e => e.Description).ToList(),
                    Success = false
                });
            }
        }

        return BadRequest(new RegisterResponseDTO()
        {
            Errors = new List<string>() { "Invalid payload" },
            Success = false
        });
    }*/

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserDTO user, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _mediator.Send(new GetUserAuthRequest(user.Email), cancellationToken);
            if (existingUser == null)
            {
                return BadRequest(new RegisterResponseDTO()
                {
                    Errors = new List<string>() { "Email address is not registered." },
                    Success = false
                });
            }
            //пароль в явном виде
            bool isUserCorrect = string.Equals(existingUser.PasswordHash, user.Password);
            if (isUserCorrect)
            {
                AuthResult authResult = await _jwtService.GenerateToken(existingUser, false);
                //return a token
                return Ok(authResult);
            }
            else
            {
                return BadRequest(new RegisterResponseDTO()
                {
                    Errors = new List<string>() { "Wrong password" },
                    Success = false
                });
            }
        }

        return BadRequest(new RegisterResponseDTO()
        {
            Errors = new List<string>() { "Invalid payload" },
            Success = false
        });
    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var verified = await _jwtService.VerifyToken(tokenRequest);
            //
            if (!verified.Success)
            {
                return BadRequest(new AuthResult()
                {
                    // Errors = new List<string> { "invalid Token" },
                    Errors = verified.Errors,
                    Success = false
                });
            }
            var tokenUser = await _mediator.Send(new GetUserAuthRequest(verified.Email), cancellationToken);
            //var tokenUser = await _userManager.FindByIdAsync(verified.UserId);
            //var response = await _mediator.Send(new GetUserRequest(id), cancellationToken);
            AuthResult authResult = await _jwtService.GenerateToken(tokenUser, false);
            //return a token
            return Ok(authResult);


        }

        return BadRequest(new AuthResult()
        {
            Errors = new List<string> { "invalid Payload" },
            Success = false
        });



    }
}
