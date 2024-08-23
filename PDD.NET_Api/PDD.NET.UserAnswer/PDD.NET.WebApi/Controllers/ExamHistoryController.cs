﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;
using PDD.NET.Application.Features.ExamHistories.Queries.GetExamHistory;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Дополнительная информация пользователя
/// </summary>
[ApiController]
[Route("api/user-answer/exam-history")]
public class ExamHistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Получить информацию о пройденом экзамене вместе с логином пользователя
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Информация о пройденом экзамене вместе с логином пользователя</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetExamHistory(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetExamHistoryRequest(id), cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Добавить информацию о пройденом экзамене
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Информация о пройденом экзамене</returns>
    [HttpPost]
    public async Task<ActionResult<CreateExamHistoryResponse>> CreateExamHistory(CreateExamHistoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}