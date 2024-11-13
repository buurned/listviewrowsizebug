using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewWithCollectionViewOrListHeightProblem.Classes
{
    public class CustomObservableCollection<T> : ObservableCollection<T>
    {
        /// <summary>
        /// UpdateRow
        /// </summary>
        /// <param name="newItem"></param>
        public void UpdateRow(T newItem)
        {
            try
            {
                if (newItem == null)
                    throw new ArgumentNullException(nameof(newItem));

                int index = this.Items.IndexOf(newItem);

                T originalItem = this.Items[index];

                this.Items[index] = newItem;

                OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                OnPropertyChanged(new PropertyChangedEventArgs("Count"));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, originalItem, index));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
