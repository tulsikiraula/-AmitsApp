using ShopSmartTool.DAL.Repositories;

namespace ShopSmartTool.DAL.UoW
{
    /// <summary>
    /// Used to define the Repository
    /// </summary>
    public interface IItemsUoW
    {
        IItemsRepository ItemsRepository { get; set; }
    }
}
