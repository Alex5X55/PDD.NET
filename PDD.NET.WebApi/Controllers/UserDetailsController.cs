using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    /// <summary>
    /// Добавить дополнительную информацию пользователя
    /// </summary>
    /// <param name="request">Запрос на добавление дополнительной информации пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Дополнительная информация пользователя</returns>
    [HttpPost]
    public async Task<ActionResult<CreateUserDetailResponse>> Create(int userId, CreateUserDetailRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateUserDetailInternalRequest(request.Name, request.Surname, request.Country, userId), cancellationToken);
        return Ok(response);
    }
}