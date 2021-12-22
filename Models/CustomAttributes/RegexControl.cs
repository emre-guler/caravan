using System;

namespace Caravan.CustomAttributes
{
    public class RegexControl : Attribute
    {
        public string RegexPattern { get; set; }
    }
}