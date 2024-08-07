﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDD.NET.Application.Features.Answers.Commands.CreateAnswer;
using PDD.NET.Application.Features.Answers.Commands.DeleteAnswer;
using PDD.NET.Application.Features.Answers.Commands.UpdateAnswer;
using PDD.NET.Application.Features.Answers.Queries.GetAllAnswers;
using PDD.NET.Application.Features.Answers.Queries.GetAnswer;
using PDD.NET.Application.Features.Answers.Queries.GetAnswerFullInfo;

namespace PDD.NET.WebApi.Controllers
{
    /// <summary>
    /// Ответы на вопросы
    /// </summary>
    [ApiController]
    [Route("api/answer-options")]
    public class AnswersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить ответ по Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Сущность Ответа</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAnswer(int id, bool fullInfo, CancellationToken cancellationToken)
        {
            if (fullInfo)
            {
                var fullInfoResponse = await _mediator.Send(new GetAnswerFullInfoRequest(id), cancellationToken);
                return Ok(fullInfoResponse);
            }
            else
            {
                var response = await _mediator.Send(new GetAnswerRequest(id), cancellationToken);
                return Ok(response);
            }
        }

        //TODO проверить - просто Task<ActionResult>
        /// <summary>
        /// Получить все ответы
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список всех ответов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllAnswerResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllAnswerRequest(), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Создать ответ по запросу
        /// </summary>
        /// <param name="request">Запрос на создание ответа</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Сущность Ответа</returns>
        [HttpPost]
        public async Task<ActionResult<CreateAnswerResponse>> Create(CreateAnswerRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Обновить информацию ответа по запросу
        /// </summary>
        /// <param name="id">Запрос на обновление информации по ответу</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("{id:int}")]
        public async Task<ActionResult<Unit>> Update(int id, UpdateAnswerRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateAnswerInternalRequest(id, request.Text, request.IsRight), cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Удалить ответ по Id
        /// </summary>
        /// <param name="id">Id ответа</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> Delete(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAnswerRequest(id), cancellationToken);
            return Ok();
        }
    }
}