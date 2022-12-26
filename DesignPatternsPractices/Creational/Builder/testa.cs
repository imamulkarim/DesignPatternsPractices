using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.Builder
{
    internal class testa
    {
        public List<string> Names { get; set; }
        public testa()
        {
            Names = new List<string>();
        }


        public testa AddData(string text)
        {
            Names.Add(text);
            return this;
        }

        public testa Build()
        {
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Names)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }
    }
}
