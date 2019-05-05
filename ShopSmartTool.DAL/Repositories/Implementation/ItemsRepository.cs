using System.Collections.Generic;
using System.Linq;
using ShopSmartTool.Entities;

namespace ShopSmartTool.DAL.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        #region Private Variables
        private Dictionary<string, int> _itemsWithCount;
        private const string _productOfferA = "Buy 3 for 130";
        private const string _productOfferB = "Buy 2 for 45";
        private const string _default = "No offers";
        #endregion Private Variables


        #region Public Methods
        /// <summary>
        /// Getting the list of all items available
        /// </summary>
        /// <returns>List<Product></returns>
        public List<Items> GetAllItems()
        {
            return new List<Items>()
            {
                new Items() { ItemId=1, ItemName="A", Price=50, Offer=_productOfferA},
                new Items() { ItemId=2, ItemName="B", Price=30, Offer=_productOfferB },
                new Items() { ItemId=3, ItemName="C", Price=20, Offer=_default},
                new Items() { ItemId=4, ItemName="D", Price=15, Offer=_default}
            };
        }
        /// <summary>
        /// Getting the total amount caluculat
        /// </summary>
        /// <param name="itemsSelected">string</param>
        /// <returns>int</returns>
        public int CalculateTotalAmount(string selectedItem)
        {
            int price = 0;
            _itemsWithCount = new Dictionary<string, int>
                {
                    { "A", selectedItem.Where(x => x == 'A').Count() },
                    { "B", selectedItem.Where(x => x == 'B').Count() },
                    { "C", selectedItem.Where(x => x == 'C').Count() },
                    { "D", selectedItem.Where(x => x == 'D').Count() }
                };
            if (_itemsWithCount != null)
            {
                var effectiveCounts = _itemsWithCount.Where(o => o.Value > 0);
                foreach (var item in effectiveCounts)
                {
                    int quotient = 0;
                    int rem = 0;
                    int itemPrice = 0;
                    int discount = 0;
                    switch (item.Key)
                    {

                        case "A":
                            itemPrice = 50;
                            discount = 130;
                            quotient = item.Value / 3;
                            rem = item.Value % 3;
                            price += quotient * discount + rem * itemPrice;
                            break;
                        case "B":
                            itemPrice = 30;
                            discount = 45;
                            quotient = item.Value / 2;
                            rem = item.Value % 2;
                            price += quotient * discount + rem * itemPrice;
                            break;
                        case "C":
                            itemPrice = 20;
                            price += item.Value * itemPrice;
                            break;
                        case "D":
                            itemPrice = 15;
                            price += item.Value * itemPrice;
                            break;
                    }
                   
                }
            }
            return price;
        }
        #endregion Public Methods
    }
}
