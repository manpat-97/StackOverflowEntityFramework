using FluentValidation;
using StackOverflowEF.Dto;

namespace StackOverflowEF
{
    public class StackOverflowEFValidator : AbstractValidator<QuestionDto>
    {
        public StackOverflowEFValidator()
        {
            RuleFor(q => q.Title)
                .NotEmpty()
                .MinimumLength(15)
                .WithMessage("Title of a question must be atleast 15 characters ");
            RuleFor(q => q.Content)
                .NotEmpty();
                
        }
    }
}
