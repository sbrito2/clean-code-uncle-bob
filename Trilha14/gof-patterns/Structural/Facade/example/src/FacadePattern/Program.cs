using System;
using FacadePattern.Facades;

namespace facade
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopFacade.GetInstanceShopFacade().BuyNotebookWithFreeShipping("teste@gmail.com", "11960221110");
        }
    }
}
