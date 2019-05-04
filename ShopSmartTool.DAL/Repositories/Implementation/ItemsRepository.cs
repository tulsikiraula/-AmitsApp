using System;
using System.Collections.Generic;
using System.Linq;
using ShopSmartTool.Entities;

namespace ShopSmartTool.DAL.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        #region Private Variables
        private Dictionary<string, int> _productsCollectionWithCount;
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
                new Items() { ItemId=1, ItemName="A", Price=50, Offer=_productOfferA },
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
            int totalPrice = 0;
            _productsCollectionWithCount = new Dictionary<string, int>
                {
                    { "A", selectedItem.Where(x => x == 'A').Count() },
                    { "B", selectedItem.Where(x => x == 'B').Count() },
                    { "C", selectedItem.Where(x => x == 'C').Count() },
                    { "D", selectedItem.Where(x => x == 'D').Count() }
                };

            totalPrice = CalculateTotalAmountWithOffers(_productsCollectionWithCount["A"], 3, 130, 50);
            totalPrice += CalculateTotalAmountWithOffers(_productsCollectionWithCount["B"], 2, 45, 30);
            totalPrice += CalculateTotalAmountWithOffers(_productsCollectionWithCount["C"], 1, 20, 20);
            totalPrice += CalculateTotalAmountWithOffers(_productsCollectionWithCount["D"], 1, 15, 15);
            
            return totalPrice;
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Calculate the amount based on offers
        /// </summary>
        /// <param name="productOccurence">int</param>
        /// <param name="itemsRequiredToAvailOffer">int</param>
        /// <param name="offerPrize">int</param>
        /// <param name="singleProductPrize">int</param>
        /// <returns>int</returns>
        private int CalculateTotalAmountWithOffers(int productOccurence, int itemsRequiredToAvailOffer, int offerPrize, int singleProductPrize)
        {
            int noOfgroups = 0;//Math.DivRem(productOccurence, itemsRequiredToAvailOffer, out int result);
            int result = 0;
            return noOfgroups * offerPrize + result * singleProductPrize;
        }
        #endregion Private Methods
    }
}
