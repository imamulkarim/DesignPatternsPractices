using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.Builder
{
    internal class ReceiptBuilder
    {
        private Receipt r;

        public ReceiptBuilder()
        {
            r = new Receipt();
        }

        public ReceiptBuilder WithName(string name)
        {
            r.Name = name;
            return this;
        }

        public ReceiptBuilder WithDate(DateTime dt)
        {
            r.Date = dt;
            return this;
        }

        public ReceiptBuilder WithItem(string text, Action<ReceiptItemBuilder> itemBuilder)
        {
            var rib = new ReceiptItemBuilder(text);
            itemBuilder(rib);
            r.AddItem(rib.Build());
            return this;
        }

        public Receipt Build()
        {
            return r;
        }
    }

    public class Receipt
    {
        private List<ReceiptItem> items = new List<ReceiptItem>();

        public string Name { get; set; }
        public DateTime Date { get; set; }

        public void AddItem(ReceiptItem item)
        {
            this.items.Add(item);
        }

        public override string ToString()
        {
            var s = Name + "\r\n" + Date + "\r\n--------------\r\n";
            foreach (var i in items)
            {
                s += i.ToString() + "\r\n";
            }
            return s;
        }
    }

    public class ReceiptItemBuilder
    {
        private ReceiptItem ri;

        public ReceiptItemBuilder(string text)
        {
            ri = new ReceiptItem(text);
        }

        public ReceiptItemBuilder WithIngredients(string ings)
        {
            ri.Ingredients = ings;
            return this;
        }

        // WithType omitted for brevity. 

        internal ReceiptItem Build()
        {
            return ri;
        }
    }

    public class ReceiptItem
    {
        private string text;

        public ReceiptItem(string text)
        {
            this.text = text;
        }

        public string Ingredients { get; set; }

        public override string ToString()
        {
            return this.text + "\r\n" + this.Ingredients;
        }
    }


}
