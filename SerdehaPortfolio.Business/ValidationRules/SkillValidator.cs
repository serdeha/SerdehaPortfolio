using FluentValidation;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.ValidationRules
{
    public class SkillValidator:AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Yetenek ismi boş bırakılamaz.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Yetenek oranı boş bırakılamaz.");
        }
    }
}
