using System.Collections.Generic;
using Unity;
using ShopSmartTool.DAL.UoW;
using ShopSmartTool.Entities;

namespace ShopSmartTool.DAL.Services
{
    public class ItemsService : IItemsService
    {

        protected readonly IUnityContainer _container;
        private IItemsUoW _itemsUoW;

        #region Constructor
        /// <summary>
        /// Initializes the Items Service
        /// </summary>
        /// <param name="container"></param>
        public ItemsService(IUnityContainer container)
        {
            _container = container;
            _itemsUoW = _container.Resolve<IItemsUoW>();
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Get all the items data
        /// </summary>
        /// <returns>List<Product></returns>
        public List<Items> GetAllItems()
        {
            return _itemsUoW.ItemsRepository.GetAllItems();
        }
        /// <summary>
        /// Calculates the total amount based on the discount/no-discount
        /// </summary>
        /// <returns>int</returns>
        public int CalculateTotalAmount(string itemsSelected)
        {
            return _itemsUoW.ItemsRepository.CalculateTotalAmount(itemsSelected);
        }
        #endregion Public Methods
    }
}
