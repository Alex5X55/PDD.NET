namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionById
{
    public sealed record GetQuestionByIdResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageData { get; set; }
        public int CategoryId { get; set; }
        public QuestionCategoryDTO Category { get; set; }
    }
}
