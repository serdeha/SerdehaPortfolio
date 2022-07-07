using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SerdehaPortfolio.WebUI.Areas.Author.Models
{
    public class UserLoginViewModel
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanını lütfen boş bırakmayınız.")]
        public string? UserName { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanını lütfen boş bırakmayınız.")]
        public string? Password { get; set; }
    }
}
