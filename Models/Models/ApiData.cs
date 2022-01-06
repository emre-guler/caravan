namespace Caravan.Models
{
    public class ApiData : BaseModel
    {
        public int SellerId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret {  get; set; }
    }
}