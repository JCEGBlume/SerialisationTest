using System;
using System.Collections.Generic;
using System.Text;

namespace SerialisationTest
{
    [Serializable]
    class Daten
    {
        public string text;

        public Daten(string text)
        {
            this.text = text;
        }
    }
}
