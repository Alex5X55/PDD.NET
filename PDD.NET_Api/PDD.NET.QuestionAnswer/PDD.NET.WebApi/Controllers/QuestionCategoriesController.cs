using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;
using PDD.NET.Application.Features.QuestionCategories.Commands.DeleteQuestionCategories;
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
    
    /// <summary>
    /// Создать категорию вопроса по запросу
    /// </summary>
    /// <param name="request">Запрос на создание категории вопроса</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Сущность Категории вопроса</returns>
    [HttpPost]
    public async Task<ActionResult<CreateQuestionCategoryResponse>> CreateAnswerOptions(CreateQuestionCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
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
        await _mediator.Send(new DeleteQuestionCategoryRequest(id), cancellationToken);
        return Ok();
    }
}