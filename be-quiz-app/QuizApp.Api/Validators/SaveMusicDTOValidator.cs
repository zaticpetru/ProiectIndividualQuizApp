using FluentValidation;
using QuizApp.Api.Resources;

namespace QuizApp.Api.Validators
{
    public class SaveMusicDTOValidator : AbstractValidator<SaveMusicDTO>
    {
        public SaveMusicDTOValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(m => m.ArtistId)
                .NotEmpty()
                .WithMessage("'Artist Id' must not be 0.");
        }
    }
}
