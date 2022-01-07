namespace Caravan.Models
{
    public class ChangePassword : BaseModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}