using FluentValidation;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.ValidationRules
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Deneyim ismi boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Deneyim ismi en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("Deneyim ismi en fazla 200 karakterden oluşmalıdır.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Çalışma tarihi boş bırakılamaz.");
            RuleFor(x => x.Date).MinimumLength(5).WithMessage("Deneyim ismi en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Date).MaximumLength(200).WithMessage("Deneyim ismi en fazla 200 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Deneyim açıklaması boş bırakılamaz.");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Deneyim açıklaması en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Deneyim açıklaması en fazla 250 karakterden oluşmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Deneyim ikonu boş bırakılamaz.");
        }
    }
}
