using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.Users.Commands.CreateUser;
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
}