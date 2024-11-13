using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ListViewWithCollectionViewOrListHeightProblem.Classes.ViewModel
{
    public class FileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _showImage = false;
        private string _title = string.Empty;
        private string _description = string.Empty;
        private string _imageSource = string.Empty;
        private bool _showDescription = false;

        public bool ShowImage
        {
            get => _showImage;
            set
            {
                if (_showImage != value)
                {
                    _showImage = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowDescription
        {
            get => _showDescription;
            set
            {
                if (_showDescription != value)
                {
                    _showDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
