using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListViewWithCollectionViewOrListHeightProblem.Classes.ViewModel
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        public EventHandlerList Events { get; }

        #region Private Properties

        private Guid _viewModel_ID;
        string _headerTitle;
        string _headerText;

        #endregion

        #region Konstruktor

        /// <summary>
        /// BaseViewModel
        /// </summary>
        public BaseViewModel(string headerTitle, string headerText) : this()
        {
            HeaderTitle = headerTitle;
            HeaderText = headerText;
        }

        /// <summary>
        /// BaseViewModel
        /// </summary>
        public BaseViewModel()
        {
            _viewModel_ID = Guid.NewGuid();
            Events = new EventHandlerList();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// HeaderText
        /// </summary>
        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                SetProperty(ref _headerText, value);
            }
        }

        /// <summary>
        /// HeaderText
        /// </summary>
        public string HeaderTitle
        {
            get
            {
                return _headerTitle;
            }
            set
            {
                SetProperty(ref _headerTitle, value);
            }
        }

        #endregion

        #region Public Methods

        protected bool SetProperty<T>(ref List<T> backingStore, List<T> value,
         [CallerMemberName] string propertyName = "",
         Action onChanged = null)
        {
            if (EqualityComparer<List<T>>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
          [CallerMemberName] string propertyName = "",
          Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public void HandlePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanged(propertyName);
        }




        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
