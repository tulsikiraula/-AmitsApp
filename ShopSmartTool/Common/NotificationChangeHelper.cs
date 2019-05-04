using System.ComponentModel;

namespace ShopSmartTool.Common
{
    public class NotificationChangeHelper : INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler of Property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the proprty by name 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
