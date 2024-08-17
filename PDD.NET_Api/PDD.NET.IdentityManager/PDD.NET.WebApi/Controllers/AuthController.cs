
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
        _jwtService = jwtService;
        _mediator = mediator;
    }

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


    /// <summary>
    /// Залогиниться в систему
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Тестовая валидация токена
    /// </summary>
    /// <param name="tokenRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("validatetoken")]
    //[HttpPost, Authorize]
    public async Task<IActionResult> ValidateTokenTest([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        if (!await _jwtService.ValidateTokenTest(tokenRequest))
        {
            return BadRequest();
        }
        return Ok();
    }

    /// <summary>
    /// Отозвать токен доступа
    /// </summary>
    /// <param name="tokenRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    //[HttpPost, Authorize]
    [Route("revoketoken")]
    public async Task<IActionResult> RevokeToken([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        var revoked = await _jwtService.RevokeToken(tokenRequest);
        
        if (!revoked.Success)
        {
            return BadRequest(new AuthResult()
            {
                // Errors = new List<string> { "invalid Token" },
                Errors = revoked.Errors,
                Success = false
            });
        }
        return Ok(revoked);
    }

    /// <summary>
    /// Обновить токен доступа.
    /// </summary>
    /// <param name="tokenRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var verified = await _jwtService.RefreshToken(tokenRequest);
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
