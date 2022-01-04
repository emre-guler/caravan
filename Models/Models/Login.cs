using Caravan.CustomAttributes;

namespace Caravan.Models
{
    public class Login : BaseModel
    {
        [RequiredArea]
        [CharacterLimit(Min = 6)]
        [ErrorMessage(Title = "MailAddressError", Message = "Bu alan boş geçilemez ve en az 6 karakterden oluşmalıdır.")]
        public string MailAddress { get; set; }
        [RequiredArea]
        [CharacterLimit(Min = 8)]
        [ErrorMessage(Title = "PasswordError", Message = "Bu alan boş geçilemez ve en az 8 karakterden oluşmalıdır.")]
        public string Password { get; set; }
    }
}