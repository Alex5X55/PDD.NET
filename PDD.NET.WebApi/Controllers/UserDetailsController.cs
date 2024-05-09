using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.UserDetails.Commands.UpdateUserDetail;
using PDD.NET.Application.Features.UserDetials.Commands.CreateUserDetail;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Дополнительная информация пользователя
/// </summary>
[ApiController]
[Route("userDetail")]
public class UserDetailController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // TODO Возможно вообще убрать метод Create, а всегда делать через Update, так как в данном случае Update содержит логику Create
    /// <summary>
    /// Добавить дополнительную информацию пользователя
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    /// <param name="request">Запрос на добавление дополнительной информации пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Дополнительная информация пользователя</returns>
    [HttpPost]
    public async Task<ActionResult<CreateUserDetailResponse>> Create(int userId, CreateUserDetailRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateUserDetailInternalRequest(request.Name, request.Surname, request.Country, userId), cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Обновить дополнительную информацию пользователя
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    /// <param name="request">Запрос на обновление дополнительной информации пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("{userId}")]
    public async Task<ActionResult<Unit>> Update(int userId, UpdateUserDetailRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateUserDetailInternalRequest(request.Name, request.Surname, request.Country, userId), cancellationToken);
        return Ok();
    }
}