﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PDD.NET.Application.Common.Constants;
using PDD.NET.Application.Features.AnswerOptions.Commands.CreateAnswerOption;
using PDD.NET.Application.Features.AnswerOptions.Commands.DeleteAnswerOption;
using PDD.NET.Application.Features.AnswerOptions.Commands.UpdateAnswerOption;
using PDD.NET.Application.Features.AnswerOptions.Queries.GetAllAnswerOptions;
using PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOption;
using PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOptionFullInfo;


namespace PDD.NET.WebApi.Controllers
{
    /// <summary>
    /// Варианты ответов на вопросы
    /// </summary>
    [ApiController]
    [Route("api/answer-options")]
    public class AnswerOptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerOptionsController(IMediator mediator)
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

        /// <summary>
        /// Получить все ответы
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список всех ответов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllAnswerResponse>>> GetAllAnswerOptions(CancellationToken cancellationToken)
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
        [HttpPost, Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<CreateAnswerResponse>> CreateAnswerOptions(CreateAnswerRequest request, CancellationToken cancellationToken)
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
        [HttpPost("{id:int}"), Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<Unit>> UpdateAnswerOptions(int id, UpdateAnswerRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new UpdateAnswerInternalRequest(id, request.Text, request.IsRight, request.QuestionId), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Удалить ответ по Id
        /// </summary>
        /// <param name="id">Id ответа</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}"), Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<Unit>> DeleteAnswerOptions(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteAnswerRequest(id), cancellationToken);
            return Ok(response);
        }
    }
}