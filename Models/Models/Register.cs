using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Caravan.CustomAttributes;

namespace Caravan.Models
{
    public class Register : BaseModel
    {
        [RequiredArea]
        [CharacterLimit(Min = 5, Max = 50)]
        [ErrorMessage(Title = "FullNameError", Message = "Bu alan boş geçilemez ve 5 - 50 karakter arasında olmalıdır.")]
        public string FullName { get; set; }


        [RequiredArea]
        [CharacterLimit(Min = 8)]
        [ErrorMessage(Title = "PasswordError", Message = "Bu alan boş geçilemez ve en az 8 karakterden oluşmalıdır.")]
        public string Password { get; set; }


        [RequiredArea]
        [CharacterLimit(Min = 6)]
        [ErrorMessage(Title = "MailAddressError", Message = "Bu alan boş geçilemez ve en az 6 karakterden oluşmalıdır.")]
        public string MailAddress { get; set; }


        [RequiredArea]
        [CharacterLimit(Min = 9, Max = 12)]
        [ErrorMessage(Title = "PhoneNumberError", Message = "Bu alan boş geçilemez ve 9 -12 karakter arasında olmalıdır.")]
        public string PhoneNumber { get; set; }

        
    }
}