using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PDD.NET.Application.Features.Questions.Commands.DeleteQuestion;
using PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;
using PDD.NET.Application.Features.Questions.Queries.GetQuestionById;
using PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId;
using PDD.NET.WebApi.Controllers;

public class QuestionsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly QuestionsController _controller;

    public QuestionsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new QuestionsController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetAllQuestions_ReturnsOkResultWithQuestions()
    {
        // Arrange
        var questions = new List<GetAllQuestionResponse>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllQuestionRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(questions);

        // Act
        var result = await _controller.GetAllQuestions(CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsAssignableFrom<IEnumerable<GetAllQuestionResponse>>(okResult.Value);
    }

    [Fact]
    public async Task GetQuestionsWithAnswerOptionsByCategoryId_ReturnsOkResultWithQuestions()
    {
        // Arrange
        var questions = new List<GetQuestionsByCategoryIdResponse>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetQuestionsByCategoryIdRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(questions);

        // Act
        var result = await _controller.GetQuestionsWithAnswerOptionsByCategoryId(1, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsAssignableFrom<IEnumerable<GetQuestionsByCategoryIdResponse>>(okResult.Value);
    }

    [Fact]
    public async Task GetQuestionById_ReturnsOkResultWithQuestion()
    {
        // Arrange
        var question = new GetQuestionByIdResponse();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetQuestionByIdRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(question);

        // Act
        var result = await _controller.GetQuestionById(1, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsType<GetQuestionByIdResponse>(okResult.Value);
    }

    [Fact]
    public async Task DeleteQuestionById_ReturnsOkResult()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteQuestionRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.DeleteQuestionById(1, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(Unit.Value, okResult.Value);
    }
}
