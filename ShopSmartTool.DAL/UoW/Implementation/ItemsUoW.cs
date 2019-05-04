using ShopSmartTool.DAL.Repositories;

namespace ShopSmartTool.DAL.UoW
{
    /// <summary>
    /// Initializes the product repository for further use
    /// </summary>
    public class ItemsUoW : IItemsUoW
    {
        #region Public Properties
        public IItemsRepository ItemsRepository { get; set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// initializes the Items UoW   
        /// </summary>
        public ItemsUoW()
        {
            ItemsRepository = new ItemsRepository();
        }
        #endregion Constructor
            

    }
}
