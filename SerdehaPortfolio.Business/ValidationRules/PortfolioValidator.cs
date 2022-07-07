using FluentValidation;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı Boş Bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Proje Resmi Boş Bırakılamaz.");
            RuleFor(x => x.ThumbnailImageUrl).NotEmpty().WithMessage("Proje Resmi Boş Bırakılamaz.");
            RuleFor(x => x.WebsiteName).NotEmpty().WithMessage("Proje Paylaşım Sitesi Boş Bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje ismi en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("Proje ismi en fazla 200 karakterden oluşabilir.");
        }
    }
}
