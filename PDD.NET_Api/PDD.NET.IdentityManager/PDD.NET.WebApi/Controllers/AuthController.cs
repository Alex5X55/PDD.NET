
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Persistence.Services;
using PDD.NET.Application.Auth;
using PDD.NET.Application.Auth.Request;
using PDD.NET.Application.Auth.Response;
using MediatR;
using PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;
using PDD.NET.Application.Features.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Authorization;

namespace PDD.NET.WebApi.Controllers;

[ApiController]
//[Route("api/[controller]")]
[Route("api/authorization/manager")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IMediator _mediator;

    public AuthController(IJwtService jwtService, IMediator mediator)
    {
        _jwtService = jwtService;
        _mediator = mediator;
    }

    /// <summary>
    /// ������� ������������ �� �������
    /// </summary>
    /// <param name="request">������ �� �������� ������������</param>
    /// <param name="cancellationToken"></param>
    /// <returns>�������� ������������</returns>
    [HttpPost("Register")]
    public async Task<ActionResult<CreateUserResponse>> Register(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    /// <summary>
    /// ������������ � �������, ������������� ������ �������
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("Login")]
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
            bool isPasswordCorrect = VerifyPassword(user.Password, existingUser.PasswordHash);
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

    /*  ��������� ������.
        �� ����: �����
        �����: �������� �� ��*/
    /// <summary>
    /// �������� ��������� �������
    /// </summary>
    /// <param name="tokenRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("Validate")]
    //[HttpPost, Authorize]
    public async Task<IActionResult> Validate([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        if (!await _jwtService.ValidateTokenTest(tokenRequest))
        {
            return BadRequest();
        }
        return Ok();
    }

    /// <summary>
    /// �������� refresh �����
    /// </summary>
    /// <param name="tokenRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    //[HttpPost]
    [HttpPost, Authorize]
    [Route("Revoke")]
    public async Task<IActionResult> Revoke([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
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

    //���� ������ ����� �� ��������� - ������ �� ������, � ��������� ������ ���������� ����� ������ ����� � ��������������� �����.
    /// <summary>
    /// ��������� � �������� ����� �������
    /// </summary>
    /// <param name="tokenRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("Verify")]
    public async Task<IActionResult> Verify([FromBody] TokenRequestDTO tokenRequest, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var verified = await _jwtService.VerifyRefreshToken(tokenRequest);
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
            //���������� ����� ������ � ��������������� �����
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
    private static bool VerifyPassword(string password, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
