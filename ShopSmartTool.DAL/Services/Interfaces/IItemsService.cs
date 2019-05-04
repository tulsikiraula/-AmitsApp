using ShopSmartTool.Entities;
using System.Collections.Generic;

namespace ShopSmartTool.DAL.Services
{
    /// <summary>
    /// Method definition for Items servicce
    /// </summary>
    public interface IItemsService
    {
        /// <summary>
        /// Getting the list of total items
        /// </summary>
        /// <returns></returns>
        List<Items> GetAllItems();
        /// <summary>
        /// Getting the total caclucated items
        /// </summary>
        /// <param name="itemsSelected"></param>
        /// <returns></returns>
        int CalculateTotalAmount(string itemsSelected);
    }
}
