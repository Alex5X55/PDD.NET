using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Common.Constants;
using PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;
using PDD.NET.Application.Features.AnalyticsData.Queries.GetUserAnalyticsData;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Аналитика
/// </summary>
[ApiController]
[Route("api/analytics")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AnalyticsDataController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnalyticsDataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить всю аналитику
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Список всей аналитики</returns>
    [HttpGet, Authorize(Roles = nameof(UserRole.Admin))]
    public async Task<ActionResult<IEnumerable<GetAllAnalyticsDataResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAnalyticsDataRequest(), cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Получить всю аналитику по пользователю
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Список всей аналитики  по пользователю</returns>
    [HttpGet("{login}"), Authorize]
    public async Task<ActionResult<IEnumerable<GetAllAnalyticsDataResponse>>> GetAnalyticsByLogin(string login, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetUserAnalyticsDataRequest(login), cancellationToken);
        return Ok(response);
    }
}