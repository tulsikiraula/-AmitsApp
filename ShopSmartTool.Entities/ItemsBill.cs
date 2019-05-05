using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopSmartTool.Entities
{
    /// <summary>
    /// Shows the total bill of the customer
    /// </summary>
    public class ItemsBill
    {
        #region Members
        /// <summary>
        /// Item Name to be displayed on total bill
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Total count of the items
        /// </summary>
        public int ItemCount { get; set; }
        #endregion Members
    }
}
