using FluentValidation;
using QuizApp.Api.Resources;

namespace QuizApp.Api.Validators
{
    public class SaveArtistDTOValidator : AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(256);
        }
    }
}
