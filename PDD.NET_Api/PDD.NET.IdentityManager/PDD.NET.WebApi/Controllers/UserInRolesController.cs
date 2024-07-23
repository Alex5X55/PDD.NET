using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.UserInRoles.Commands.CreateUserInRole;
using PDD.NET.Application.Features.UserInRoles.Commands.DeleteUserInRole;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Вхождение пользователя в роль
/// </summary>
[ApiController]
[Route("api/authorization/userInRole")]
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
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="roleId">Идентификатор роли</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("{userId:int}/{roleId:int}")]
    public async Task<ActionResult<Unit>> Create(int userId, int roleId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CreateUserInRoleRequest(userId, roleId), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удалить пользователя из роли
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="roleId">Идентификатор роли</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{userId:int}/{roleId:int}")]
    public async Task<ActionResult<Unit>> Delete(int userId, int roleId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteUserInRoleRequest(userId, roleId), cancellationToken);
        return Ok();
    }
}