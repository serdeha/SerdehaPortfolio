using FluentValidation;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.ValidationRules
{
    public class ServiceValidator:AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Service başlığı boş bırakılamaz.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Service başlığı en az 5 karakter olabilir.");
            RuleFor(x => x.Title).MaximumLength(250).WithMessage("Service başlığı en fazla 5 karakter olabilir.");
        }
    }
}
