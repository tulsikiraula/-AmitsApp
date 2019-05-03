using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopSmartTool.Entities
{
    /// <summary>
    /// The Item enitity class , which contains the description of the item
    /// </summary>
    public class Items
    {
        #region Members
        /// <summary>
        /// The item id to uniquely identify the item
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// The name of the item
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// The price of the item
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// The offer available on the item
        /// </summary>
        public string Offer { get; set; }

        #endregion Members
    }
}
