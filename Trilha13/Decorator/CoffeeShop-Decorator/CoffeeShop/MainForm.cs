using System;
using System.Drawing;
using System.Windows.Forms;
using CoffeeShop.Concrete;
using CoffeeShop.Decorators;

namespace CoffeeShop
{
    public partial class MainForm : Form
    {
        #region Constants
        private readonly Color AnchorNodeTextColor = Color.White;
        private readonly Color AnchorNodeTextBackground = Color.Black;
        private readonly Color PrimaryItemTextColor = Color.White;
        private readonly Color PrimaryItemTextBackground = Color.Black;
        private readonly Color SubItemTextColor = Color.Gray;
        private readonly Color SubItemTextBackground = Color.Black;
        #endregion

        private enum ItemNodeType
        {
            RootItem = 0,
            SubItem = 1
        }


        private OrderItems<Beverage> _orderItems;
        private ItemTreeNode _rootNode;
        private ItemTreeNode _lastItemNodeAdded;
        private Beverage _lastBeverageAdded;

        public MainForm()
        {
            InitializeComponent();

            _orderItems = new OrderItems<Beverage>();

            InitOrderTree();
            RefreshOrderTree();
            buttonRemoveSelectedItem.Visible = false;
            panelOptions.Visible = false;
        }

        private void InitOrderTree()
        {
            // Create the TreeView Root Node
            _rootNode = new ItemTreeNode();
            _rootNode.Text = "Your Order";
            _rootNode.ForeColor = AnchorNodeTextColor;
            _rootNode.BackColor = AnchorNodeTextBackground;
            _rootNode.ImageIndex = 0;
            _rootNode.SelectedImageIndex = 0;
            treeOrderList.Nodes.Add(_rootNode);
        }

        private void RefreshOrderTree()
        {
            foreach (var i in _orderItems.GetItems())
            {
                Beverage rootItem = i.RootItem();
                ItemTreeNode rootNode = AddRootItem(rootItem);
                foreach (var s in i.SubItems())
                {
                    AddSubItem(rootNode, s);
                }
            }

            treeOrderList.ExpandAll();
        }

        private ItemTreeNode AddRootItem(Beverage b)
        {
            // Store a reference to the last item added.
            _lastBeverageAdded = b;

            _orderItems.AddItem(new OrderItem<Beverage>(b));

            var node = CreateNode(ItemNodeType.RootItem, b);
            _rootNode.Nodes.Add(node);

            treeOrderList.ExpandAll();
            panelOptions.Visible = true;
            UpdateTotals();
            return node;
        }

        private void AddSubItem(ItemTreeNode parentItemNode, Beverage b)
        {
            // TODO - Need to implement the following correctly.
            // parentItemNode is not yet used.
            _orderItems.AddItem(parentItemNode, new OrderItem<Beverage>(b));

            var node = CreateNode(ItemNodeType.SubItem, b);
            parentItemNode.Nodes.Add(node);

            buttonRemoveSelectedItem.Visible = false;
            UpdateTotals();
            treeOrderList.ExpandAll();
        }

        private ItemTreeNode CreateNode(ItemNodeType nodeType, Beverage b)
        {
            ItemTreeNode node = null;
            if (nodeType == ItemNodeType.RootItem)
            {
                node = CreateItemNode(b);
            }
            else if (nodeType == ItemNodeType.SubItem)
            {
                node = CreateSubItemNode(b);
            }
            return node;
        }

        private ItemTreeNode CreateItemNode(Beverage b)
        {
            var node = new ItemTreeNode(b);
            // TODO - Need to figure out a way to get this to work.
            //string description = (b as BeverageDecorator).GetDecoratorDescriptionOnly();

            string cost = string.Format("{0,15:c}", $"[{b.Cost}]");

            node.Text = string.Format("{0} {1}", b.Description, cost);
            node.ForeColor = PrimaryItemTextColor;
            node.BackColor = PrimaryItemTextBackground;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            return node;
        }

        private ItemTreeNode CreateSubItemNode(Beverage b)
        {
            var node = new ItemTreeNode(b);
            // TODO - Need to figure out a way to get this to work.
            //string description = (b as BeverageDecorator).GetDecoratorDescriptionOnly();

            string cost = string.Format("{0,15:c}", $"[{b.Cost}]");

            node.Text = string.Format("{0,30} {1}", b.Description, cost);
            node.ForeColor = SubItemTextColor;
            node.BackColor = SubItemTextBackground;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            return node;
        }

        private void UpdateTotals()
        {
            decimal cost = _orderItems.GetTotalCost();
            labelSubTotal.Text = string.Format("{0:c}", cost);
            labelTotal.Text = string.Format("{0:c}", cost);
        }


        private void AddItemClickHandler(object sender, EventArgs e)
        {
            Beverage obj = null;
            switch (((Button)sender).Name.ToLower())
            {
                case "buttondripcoffeesmall": obj = new DripCoffeeSmall(); break;
                case "buttondripcoffeemedium": obj = new DripCoffeeMedium(); break;
                case "buttondripcoffeelarge": obj = new DripCoffeeLarge(); break;

                case "buttonlattesmall": obj = new LatteSmall(); break;
                case "buttonlattemedium": obj = new LatteSmall(); break;
                case "buttonlattelarge": obj = new LatteSmall(); break;

                case "buttonespressosmall": obj = new EspressoSmall(); break;
                case "buttonespressomedium": obj = new EspressoMedium(); break;
                case "buttonespressolarge": obj = new EspressoLarge(); break;

                default:
                    // TODO - Need to catch this somewhere and display
                    throw new ArgumentNullException("Unknown Item Selected");
            }

            _lastItemNodeAdded = AddRootItem(obj);
        }

        private void AddSubItemClickHandler(object sender, EventArgs e)
        {
            Beverage obj = null;
            switch (((Button)sender).Name)
            {
                case "buttonMilkSoy": obj = new MilkSoyDecorator(_lastBeverageAdded); break;
                case "buttonMilkSkim": obj = new MilkSkimDecorator(_lastBeverageAdded); break;
                case "buttonMilk1": obj = new Milk1Decorator(_lastBeverageAdded); break;
                case "buttonMilk2": obj = new Milk2Decorator(_lastBeverageAdded); break;
                case "buttonMilkWhole": obj = new MilkWholeDecorator(_lastBeverageAdded); break;

                case "buttonFlavorCaramel": obj = new CaramelDecorator(_lastBeverageAdded); break;
                case "buttonFlavorHazelnut": obj = new HazelnutSyrupDecorator(_lastBeverageAdded); break;
                case "buttonFlavorChocolate": obj = new ChocolateDecorator(_lastBeverageAdded); break;

                case "buttonDecaf": obj = new DecafDecorator(_lastBeverageAdded); break;

                default:
                    // TODO - Need to catch this somewhere and display
                    throw new ArgumentNullException("Unknown Sub-Item Selected");
            }

            AddSubItem(_lastItemNodeAdded, obj);
        }

        private void treeOrderList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonRemoveSelectedItem.Visible = true;
        }

        private void buttonRemoveSelectedItem_Click(object sender, EventArgs e)
        {
            ItemTreeNode node = treeOrderList.SelectedNode as ItemTreeNode;
            node.Remove();

            buttonRemoveSelectedItem.Visible = false;
            UpdateTotals();
            // Todo : Need to remove item from the _orderItems object
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            treeOrderList.Nodes.Clear();
            _orderItems.Clear();
            UpdateTotals();
            InitOrderTree();
            panelOptions.Visible = false;
            buttonRemoveSelectedItem.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
