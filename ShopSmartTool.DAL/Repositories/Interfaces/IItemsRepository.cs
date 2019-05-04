using System.Collections.Generic;
using ShopSmartTool.Entities;

namespace ShopSmartTool.DAL.Repositories
{
    /// <summary>
    /// Defines the methods which would be consumed from the presentation layer
    /// </summary>
    public interface IItemsRepository
    {
        /// <summary>
        /// Getting the list of total items
        /// </summary>
        /// <returns></returns>
        List<Items> GetAllItems();
        /// <summary>
        /// Calculating the total amount
        /// </summary>
        /// <param name="itemsSelected"></param>
        /// <returns></returns>
        int CalculateTotalAmount(string selectedItem);
    }
}
