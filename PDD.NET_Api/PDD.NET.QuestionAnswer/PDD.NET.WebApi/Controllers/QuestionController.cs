using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;
using PDD.NET.Application.Features.Questions.Queries.GetQuestionById;
using PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId;

namespace PDD.NET.WebApi.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить все вопросы
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список всех вопросов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllQuestionResponse>>> GetAllQuestions(CancellationToken cancellationToken)
        {
            var questions = await _mediator.Send(new GetAllQuestionRequest(), cancellationToken);
            return Ok(questions);
        }

        /// <summary>
        /// Получить все вопросы по идентификатору категории
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список всех вопросов по категории</returns>
        [HttpGet("categoryId/{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<GetQuestionsByCategoryIdResponse>>> GetQuestionsByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var questions = await _mediator.Send(new GetQuestionsByCategoryIdRequest(categoryId), cancellationToken);
            return Ok(questions);
        }


        /// <summary>
        /// Получить вопрос по идентификатору
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Вопрос</returns>
        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<GetQuestionByIdResponse>> GetQuestionById(int id, CancellationToken cancellationToken)
        {
            var questions = await _mediator.Send(new GetQuestionByIdRequest(id), cancellationToken);
            return Ok(questions);
        }
    }
}
