using System;

namespace Caravan.CustomAttributes
{
    public class ErrorMessage : Attribute
    {
        public string Title { get; set; }
        public string Message {  get; set; }
    }
}