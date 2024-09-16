using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public class ItemTreeNode : TreeNode
    {
        private static int nextId = 0;

        public int Id { get; set; }
        public decimal Cost { get; private set; }
        public ItemTreeNode()
        {
        }

        public ItemTreeNode(Beverage b)
        {
            Id = nextId++;
            Cost = b.Cost;
        }
    }
}
