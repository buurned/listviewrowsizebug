using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewWithCollectionViewOrListHeightProblem.Classes.ViewModel
{
    public class ItemsViewModel : BaseViewModel
    {
        private ObservableCollection<FileViewModel> _fileVMs;

        /// <summary>
        /// FileVMs
        /// </summary>
        public ObservableCollection<FileViewModel> FileVMs
        {
            get => _fileVMs;
            set
            {
                SetProperty(ref _fileVMs, value, nameof(FileVMs));
            }
        }

        private CustomObservableCollection<FileViewModel> _fileVMsWA;

        /// <summary>
        /// FileVMs
        /// </summary>
        public CustomObservableCollection<FileViewModel> FileVMsWA
        {
            get => _fileVMsWA;
            set
            {
                SetProperty(ref _fileVMsWA, value, nameof(_fileVMsWA));
            }
        }
    }
}
