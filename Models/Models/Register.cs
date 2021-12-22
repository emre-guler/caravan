using System.ComponentModel.DataAnnotations;
using Carvan.CustomAttributes;

namespace Caravan.Model
{
    public class Register : BaseModel
    {
        [RequiredArea]
        [CharacterLimit(Min = 5, Max = 50)]
        public string FullName { get; set; }


        [RequiredArea]
        [CharacterLimit(Min = 5)]
        [RegexControl(RegexPattern = "")]
        public string Password { get; set; }


        [RequiredArea]
        [CharacterLimit(Min = 6)]
        [RegexControl(RegexPattern = "")]
        public string MailAddress { get; set; }


        [RequiredArea]
        [CharacterLimit(Min = 9, Max = 12)]
        [RegexControl(RegexPattern = "")]
        public string PhoneNumber { get; set; }

        
    }
}