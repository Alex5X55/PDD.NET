﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.QuestionCategories.Queries.GetAllQuestionCategories;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Категории вопросов
/// </summary>
[ApiController]
[Route("api/question-categories")]
public class QuestionCategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Получить все категории вопросов
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Список всех категорий вопросов</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllQuestionCategoriesResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllQuestionCategoriesRequest(), cancellationToken);
        return Ok(response);
    }
}