using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class OrderItem<T> where T : Beverage
    {
        private T _rootItem;
        private ICollection<T> _subItems;

        public OrderItem(T b)
        {
            AddItem(b);
        }

        public T RootItem()
        {
            return _rootItem;
        }

        public ICollection<T> SubItems()
        {
            return _subItems;
        }

        public void AddItem(T b)
        {
            if (_rootItem == null)
            {
                // Root Item
                _rootItem = b;
            }
            else
            {
                // Sub-Items
                AddSubItem(b);
            }
        }

        public void AddSubItem(T b)
        {
            if (_subItems == null)
            {
                _subItems = new List<T>();
            }

            _subItems.Add(b);
        }

        public decimal GetTotalCost()
        {
            decimal totalCost = _rootItem.Cost;
            foreach(var i in _subItems)
            {
                totalCost += i.Cost;
            }
            return totalCost;
        }
    }
}
