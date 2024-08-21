using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.Questions.Commands.CreateQuestion;
using PDD.NET.Application.Features.Questions.Commands.DeleteQuestion;
using PDD.NET.Application.Features.Questions.Commands.UpdateQuestion;
using PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;
using PDD.NET.Application.Features.Questions.Queries.GetQuestionById;
using PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId;

namespace PDD.NET.WebApi.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить все вопросы c вариантами ответов
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список всех вопросов c вариантами ответов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllQuestionResponse>>> GetAllQuestions(CancellationToken cancellationToken)
        {
            var questions = await _mediator.Send(new GetAllQuestionRequest(), cancellationToken);
            return Ok(questions);
        }

        /// <summary>
        /// Получить все вопросы с вариантами ответов по идентификатору категории
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список всех вопросов с вариантами ответов по категории</returns>
        [HttpGet("category/{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<GetQuestionsByCategoryIdResponse>>> GetQuestionsWithAnswerOptionsByCategoryId(int categoryId, CancellationToken cancellationToken)
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
        
        /// <summary>
        /// Создать вопрос по запросу
        /// </summary>
        /// <param name="request">Запрос на создание вопроса</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Сущность вопроса</returns>
        [HttpPost]
        public async Task<ActionResult<CreateQuestionResponse>> CreateQuestion(CreateQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        
        /// <summary>
        /// Обновить информацию вопроса по запросу
        /// </summary>
        /// <param name="id">Запрос на обновление информации по вопросу</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("{id:int}")]
        public async Task<ActionResult<Unit>> UpdateAnswerOptions(int id, UpdateQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new UpdateQuestionInternalRequest(id, request.CategoryId, request.Text, request.ImageData), cancellationToken);
            return Ok(response);
        }
        
        /// <summary>
        /// Удалить вопрос по Id
        /// </summary>
        /// <param name="id">Id вопроса</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> DeleteQuestionById(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteQuestionRequest(id), cancellationToken);
            return Ok();
        }
    }
}
