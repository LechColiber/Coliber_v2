using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ksiazki
{
    class SubfieldClass
    {
        public string Tag;
        public string Ind1;
        public string Ind2;
        public string Code;
        public string Value;

        public SubfieldClass(string Tag, string Ind1, string Ind2, string Code, string Value)
        {
            this.Tag = Tag;
            this.Ind1 = Ind1;
            this.Ind2 = Ind2;
            this.Code = Code;
            this.Value = Value;
        }

        public override string ToString()
        {
            return Tag + " " + Ind1 + " " + Ind2 + " " + Code + " " + Value;
        }
    }
}
