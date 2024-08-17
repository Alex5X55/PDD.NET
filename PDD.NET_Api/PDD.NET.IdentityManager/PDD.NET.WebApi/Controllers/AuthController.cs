
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Persistence.Services;
using PDD.NET.Application.Auth;
using PDD.NET.Application.Auth.Request;
using PDD.NET.Application.Auth.Response;
using MediatR;
using PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;
using PDD.NET.Application.Features.Users.Commands.CreateUser;

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

    public AuthController(IJwtService jwtService, IMediator mediator)
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
    /// <summary>
    /// Создать пользователя по запросу
    /// </summary>
    /// <param name="request">Запрос на создание пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Сущность Пользователя</returns>
    [HttpPost("register")]
    public async Task<ActionResult<CreateUserResponse>> Register(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO user, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _mediator.Send(new GetUserAuthRequest(user.Email), cancellationToken);
            if (existingUser == null) //CreateUserHandler for this
            {
                return BadRequest(new RegisterResponseDTO()
                {
                    Errors = new List<string>() { "Email address is not registered." },
                    Success = false
                });
            }
            bool isPasswordCorrect = Verify(user.Password, existingUser.PasswordHash);
            if (isPasswordCorrect)
            {
                AuthResult authResult = await _jwtService.GenerateToken(existingUser);
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

    /*  Валидация токена.
        на вход: токен
        выход: валидный ли он*/
    [HttpPost("validatetoken")]
    //[HttpPost, Authorize]
    public async Task<IActionResult> ValidateToken([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        return Ok();
    }

    //Отозвать токен
    [HttpPost]
    //[HttpPost, Authorize]
    [Route("revoketoken")]
    public IActionResult Revoke()
    {
        return Ok();
    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var verified = await _jwtService.UpdateToken(tokenRequest);
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

            //var response = await _mediator.Send(new GetUserRequest(id), cancellationToken);
            //генерируем новый рефреш и авторизационный токен
            AuthResult authResult = await _jwtService.GenerateToken(tokenUser);
            //return a token
            return Ok(authResult);
        }

        return BadRequest(new AuthResult()
        {
            Errors = new List<string> { "invalid Payload" },
            Success = false
        });
    }
    private static bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
