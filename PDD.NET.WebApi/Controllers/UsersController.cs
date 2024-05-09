using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.Users.Commands.CreateUser;
using PDD.NET.Application.Features.Users.Commands.DeleteUser;
using PDD.NET.Application.Features.Users.Commands.UpdateUser;
using PDD.NET.Application.Features.Users.Queries.GetAllUser;
using PDD.NET.Application.Features.Users.Queries.GetUser;
using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Пользователи
/// </summary>
[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить пользователя по Id
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Сущность Пользователя</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id, bool fullInfo, CancellationToken cancellationToken)
    {
        if (fullInfo)
        {
            var fullInfoResponse = await _mediator.Send(new GetUserFullInfoRequest(id), cancellationToken);
            return Ok(fullInfoResponse);
        }
        else
        {
            var response = await _mediator.Send(new GetUserRequest(id), cancellationToken);
            return Ok(response);
        }
    }

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Список всех пользователей</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Создать пользователя по запросу
    /// </summary>
    /// <param name="request">Запрос на создание пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Сущность Пользователя</returns>
    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Обновить информацию пользователя по запросу
    /// </summary>
    /// <param name="id">Запрос на обновление информации пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Сущность Пользователя</returns>
    [HttpPost("{id}")]
    public async Task<ActionResult<UpdateUserResponse>> Update(int id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateUserInternalRequest(id, request.Login, request.Email), cancellationToken);
        return Ok(response);
    }


    /// <summary>
    /// Удалить пользователя по Id
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Id пользователя</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<DeleteUserResponse>> Delete(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteUserRequest(id), cancellationToken);
        return Ok(response);
    }
}