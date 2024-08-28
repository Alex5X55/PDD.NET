using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Common.Constants;
using PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;
using PDD.NET.Application.Features.QuestionCategories.Commands.DeleteQuestionCategories;
using PDD.NET.Application.Features.QuestionCategories.Commands.UpdateQuestionCategory;
using PDD.NET.Application.Features.QuestionCategories.Queries.GetAllQuestionCategories;

namespace PDD.NET.WebAPI.Controllers;

/// <summary>
/// Категории вопросов
/// </summary>
[ApiController]
[Route("api/question-categories")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
    [HttpGet, Authorize(Roles = nameof(UserRole.Admin))]
    public async Task<ActionResult<IEnumerable<GetAllQuestionCategoriesResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllQuestionCategoriesRequest(), cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Создать категорию вопроса по запросу
    /// </summary>
    /// <param name="request">Запрос на создание категории вопроса</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Сущность Категории вопроса</returns>
    [HttpPost, Authorize(Roles = nameof(UserRole.Admin))]
    public async Task<ActionResult<CreateQuestionCategoryResponse>> CreateAnswerOptions(CreateQuestionCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Обновить информацию категории вопроса по запросу
    /// </summary>
    /// <param name="id">Запрос на обновление информации по категории вопросу</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("{id:int}")]
    public async Task<ActionResult<Unit>> UpdateQuestionCategory(int id, UpdateQuestionCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateQuestionCategoryInternalRequest(id, request.Text), cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Удалить категорию по Id
    /// </summary>
    /// <param name="id">Id категории</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Unit>> DeleteQuestionCategory(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteQuestionCategoryRequest(id), cancellationToken);
        return Ok(response);
    }
}