using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopSmartTool.Common;
using System.Collections.ObjectModel;
using ShopSmartTool.Entities;
using Unity;
using System.Windows.Input;
using ShopSmartTool.DAL.Services;
using ShopSmartTool.DAL.Repositories;
using ShopSmartTool.DAL.UoW;


namespace ShopSmartTool.ViewModel
{
    /// <summary>
    /// The view model of the shop smart tool, data bindings, commands etc
    /// </summary>
    public class ShopSmartToolViewModel : NotificationChangeHelper
    {
        #region Priavte Variables
        private readonly IUnityContainer _container;
        private ObservableCollection<Items> _itemsList;
        private Items _selectedItem;
        private string _itemsSelected;
        private string _totalAmount = "£0";
        private IItemsService _itemService;
        #endregion Priavte Variables

        #region Commands
        public ICommand CalculateTotalAmountCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand RemoveFromCartCommand { get; set; }
        #endregion

        #region Public Properties
        public ObservableCollection<Items> ItemsList
        {
            get
            {
                return _itemsList;
            }
            set
            {
                _itemsList = value;
                OnPropertyChanged("ItemsList");
            }
        }

        public Items SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public string ItemsSelected
        {
            get
            {
                return _itemsSelected;
            }
            set
            {
                _itemsSelected = value;
                OnPropertyChanged("ItemsSelected");
            }
        }

        public string TotalAmount
        {
            get
            {
                return _totalAmount;
            }
            set
            {
                _totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initilizes the Shop Smart Tool ViewModel
        /// </summary>
        public ShopSmartToolViewModel()
        {
            _container = new UnityContainer();
            _container.RegisterType<IItemsRepository, ItemsRepository>();
            _container.RegisterType<IItemsUoW, ItemsUoW>();
            _container.RegisterType<IItemsService, ItemsService>();
            AddToCartCommand = new RelayCommand(AddToCart);
            RemoveFromCartCommand = new RelayCommand(RemoveFromCart);
            _itemService = _container.Resolve<IItemsService>();
            if (_itemService != null)
                ItemsList = new ObservableCollection<Items>(_itemService.GetAllItems());
        }
        #endregion Constructor

        #region Private Methods
        /// <summary>
        /// Adds items to the cart
        /// </summary>
        /// <param name="obj"></param>
        private void AddToCart(object obj)
        {
            if (obj != null)
                ItemsSelected += obj.ToString();

            // Calculate the total amount when added to the cart
            if (!string.IsNullOrWhiteSpace(ItemsSelected))
            {
                if (_itemService != null)
                    TotalAmount = string.Concat("£", _itemService.CalculateTotalAmount(ItemsSelected).ToString());
            }
        }

        /// <summary>
        /// Clears the items from the cart
        /// </summary>
        /// <param name="obj"></param>
        private void RemoveFromCart(object obj)
        {
            if (!string.IsNullOrWhiteSpace(ItemsSelected))
            {
                ItemsSelected = ItemsSelected.Remove(ItemsSelected.Length - 1);
                TotalAmount = string.Concat("£", _itemService.CalculateTotalAmount(ItemsSelected).ToString());
            }
        }
        #endregion Private Methods
    }
}
