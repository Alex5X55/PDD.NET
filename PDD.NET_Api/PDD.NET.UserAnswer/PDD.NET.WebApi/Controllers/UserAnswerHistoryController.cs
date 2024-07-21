using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.UserInAnswerHistory.Queries.GetAllUserAnswerHistory;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// История ответов на вопросы пользователей
/// </summary>
[ApiController]
[Route("api/user-answer/history")]
public class UserAnswerHistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserAnswerHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // TODO добавить получить историю конкретного пользователя, или универсальный контроллер
    /// <summary>
    /// Получить всю историю ответов всех пользователей
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Список всей истории</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllUserAnswerHistoryResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserAnswerHistoryRequest(), cancellationToken);
        return Ok(response);
    }
}