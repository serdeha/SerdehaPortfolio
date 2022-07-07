using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SerdehaPortfolio.WebUI.Areas.Author.Models
{
    public class UserRegisterViewModel
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(5,ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(100,ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        public string? UserName { get; set; }
        [DisplayName("İsim")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        public string? FirstName { get; set; }
        [DisplayName("Soyisim")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        public string? LastName { get; set; }
        [DisplayName("Fotoğraf")]
        public IFormFile? ImageFile { get; set; }
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(8, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        public string? Password { get; set; }
        [DisplayName("Şifre Tekrarı")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "Lütfen şifrelerin eşleştiğinden emin olunuz.")]
        public string? ConfirmPassword { get; set; }
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(10, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        public string? Mail { get; set; }
    }
}
