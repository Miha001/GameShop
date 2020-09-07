using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Characteristic ch, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Ch.CharacteristicId == ch.CharacteristicId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Ch = ch,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Characteristic ch)
        {
            lineCollection.RemoveAll(l => l.Ch.CharacteristicId == ch.CharacteristicId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Ch.SellingPrice * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Characteristic Ch { get; set; }
        public int Quantity { get; set; }
    }
}



