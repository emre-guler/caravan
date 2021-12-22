using System;

namespace Caravan.CustomAttributes
{
    public class CharacterLimit : Attribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}