using System;

namespace Carvan.CustomAttributes
{
    public class RegexControl : Attribute
    {
        public string RegexPattern { get; set; }
    }
}