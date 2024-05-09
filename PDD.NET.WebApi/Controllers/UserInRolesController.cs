using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.UserInRoles.Commands.CreateUserInRole;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Вхождение пользователя в роль
/// </summary>
[ApiController]
[Route("userInRole")]
public class UserInRoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserInRoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Добавить пользователя в роль
    /// </summary>
    /// <param name="request">Запрос на добавление пользователя в роль</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Unit>> Create(CreateUserInRoleRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return Ok();
    }
}