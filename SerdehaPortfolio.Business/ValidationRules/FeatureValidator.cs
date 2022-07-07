using FluentValidation;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.ValidationRules
{
    public class FeatureValidator:AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.");
            RuleFor(x => x.Header).NotEmpty().WithMessage("2. alan boş bırakılamaz.");
            RuleFor(x => x.Header).MinimumLength(3).WithMessage("2. alan en az 3 kelime ile oluşturulabilir.");
            RuleFor(x => x.Header).MaximumLength(200).WithMessage("2. en fazla 200 kelime ile oluşturulabilir.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim alanı en az 3 kelime ile oluşturulabilir.");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("İsim alanı en fazla 200 kelime ile oluşturulabilir.");
        }
    }
}
