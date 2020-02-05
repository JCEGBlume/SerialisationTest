using System;
using System.Collections.Generic;
using System.Text;

namespace SerialisationTest
{
    [Serializable]
    public class Daten
    {
        public string text;

        public Daten() { }
        public Daten(string text)
        {
            this.text = text;
        }
    }
}
