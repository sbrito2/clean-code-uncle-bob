using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class OrderItems<T> where T : Beverage
    {
        private ICollection<OrderItem<T>> _allItems;

        public OrderItems()
        {
            _allItems = new List<OrderItem<T>>();
        }

        public void AddItem(OrderItem<T> item)
        {
            _allItems.Add(item);
        }

        public void AddItem(ItemTreeNode parentNode, OrderItem<T> item)
        {
            //parentNode.
            AddItem(item);
        }

        public IEnumerable<OrderItem<T>> GetItems()
        {
            return _allItems;
        }

        public decimal GetTotalCost()
        {
            decimal cost = 0M;
            foreach (var i in GetItems())
            {
                T rootItem = i.RootItem();
                cost += rootItem.Cost;
                if (i.SubItems()?.Count > 0)
                {
                    foreach (var s in i.SubItems())
                    {
                        cost += s.Cost;
                    }
                }
            }
            return cost;
        }

        public void Clear()
        {
            _allItems.Clear();
        }
    }
}
