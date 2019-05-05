﻿using System.Linq;
using ShopSmartTool.Common;
using System.Collections.ObjectModel;
using ShopSmartTool.Entities;
using Unity;
using System.Windows.Input;
using ShopSmartTool.DAL.Services;
using ShopSmartTool.DAL.Repositories;
using ShopSmartTool.DAL.UoW;
using System.Windows;


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
        private ObservableCollection<ItemsBill> _itemsBillInfo;
        private string _itemsSelected;
        private int _totalAmount = 0;
        private IItemsService _itemService;
        #endregion Priavte Variables

        #region Commands
        public ICommand CalculateTotalAmountCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand RemoveFromCartCommand { get; set; }
        #endregion

        #region Public Properties
        /// <summary>
        /// List of Items to be shown on UI
        /// </summary>
        public ObservableCollection<Items> ItemsList
        {
            get { return _itemsList; }
            set { _itemsList = value; OnPropertyChanged("ItemsList"); }
        }
        /// <summary>
        /// Bill information for client
        /// </summary>
        public ObservableCollection<ItemsBill> ItemsBillInfo
        {
            get { return _itemsBillInfo; }
            set { _itemsBillInfo = value; OnPropertyChanged("ItemsBillInfo"); }
        }
        /// <summary>
        /// Items selected/removed for the cart
        /// </summary>
        public string ItemsSelected
        {
            get { return _itemsSelected; }
            set { _itemsSelected = value; OnPropertyChanged("ItemsSelected"); }
        }
        /// <summary>
        /// Total billable amount
        /// </summary>
        public int TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; OnPropertyChanged("TotalAmount"); }
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
            PrepareItemsBillInfo();
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
                    TotalAmount = _itemService.CalculateTotalAmount(ItemsSelected);
            }
            PrepareItemsBillInfo();
        }

        /// <summary>
        /// Remove the particular items from the cart
        /// </summary>
        /// <param name="obj"></param>
        private void RemoveFromCart(object obj)
        {
            if (obj != null)
            {
                if (!string.IsNullOrWhiteSpace(ItemsSelected) && ItemsSelected.Contains(obj.ToString()))
                {
                    // Calculate the total amount when removed from the cart
                    ItemsSelected = ItemsSelected.Remove(ItemsSelected.IndexOf(obj.ToString()), 1);
                    PrepareItemsBillInfo();
                    TotalAmount = _itemService.CalculateTotalAmount(ItemsSelected);

                }
                else
                {
                    MessageBox.Show(string.Concat("No item [", obj.ToString(), "] is available to delete from cart"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Prepares the items bill information
        /// </summary>
        private void PrepareItemsBillInfo()
        {
            ItemsBillInfo = new ObservableCollection<ItemsBill>()
            { 
                new ItemsBill { ItemName = "A", ItemCount = string.IsNullOrWhiteSpace(ItemsSelected)?0: ItemsSelected.Where(o => o == 'A').Count() }, 
                new ItemsBill { ItemName = "B", ItemCount = string.IsNullOrWhiteSpace(ItemsSelected)?0:ItemsSelected.Where(o => o == 'B').Count() } ,
                new ItemsBill { ItemName = "C", ItemCount = string.IsNullOrWhiteSpace(ItemsSelected)?0: ItemsSelected.Where(o => o == 'C').Count() } ,
                new ItemsBill { ItemName = "D", ItemCount = string.IsNullOrWhiteSpace(ItemsSelected)?0:ItemsSelected.Where(o => o == 'D').Count() } 
            };
        }
        #endregion Private Methods
    }
}
