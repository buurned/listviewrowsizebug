using ListViewWithCollectionViewOrListHeightProblem.Classes;
using ListViewWithCollectionViewOrListHeightProblem.Classes.ViewModel;
using System.Collections.ObjectModel;

namespace ListViewWithCollectionViewOrListHeightProblem
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public ItemsViewModel itemsViewModel;
        public ItemsViewModel itemsViewModelWorkaround;

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            itemsViewModel = new ItemsViewModel();
            itemsViewModel.FileVMs = new ObservableCollection<FileViewModel>()
            {
                new FileViewModel() { Title = "Test1 Image", ImageSource = "image1.png" },
                new FileViewModel() { Title = "Test2 Description", Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est " },
                new FileViewModel() { Title = "Test3 Image", ImageSource = "image2.png" },
                new FileViewModel() { Title = "Test4 Description", Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est " },
                new FileViewModel() { Title = "Test5 Image", ImageSource = "image3.png" }
            };
            LvFileVMs.ItemsSource = itemsViewModel.FileVMs;

            itemsViewModelWorkaround = new ItemsViewModel();
            itemsViewModelWorkaround.FileVMsWA = new CustomObservableCollection<FileViewModel>()
            {
                new FileViewModel() { Title = "Test1 Image", ImageSource = "image1.png" },
                new FileViewModel() { Title = "Test2 Description", Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est " },
                new FileViewModel() { Title = "Test3 Image", ImageSource = "image2.png" },
                new FileViewModel() { Title = "Test4 Description", Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est " },
                new FileViewModel() { Title = "Test5 Image", ImageSource = "image3.png" }
            };
            LvFileVMsWorkaround.ItemsSource = itemsViewModelWorkaround.FileVMsWA;
            base.OnAppearing();
        }

        private void LvFileVMs_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            FileViewModel fVM = (FileViewModel)e.Item;
            if (fVM != null)
            {
                if (String.IsNullOrEmpty(fVM.ImageSource))
                    fVM.ShowDescription = !fVM.ShowDescription;
                else
                    fVM.ShowImage = !fVM.ShowImage;

            }
        }

        private void LvFileVMsWorkaround_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            FileViewModel fVM = (FileViewModel)e.Item;
            if (fVM != null)
            {
                if (String.IsNullOrEmpty(fVM.ImageSource))
                    fVM.ShowDescription = !fVM.ShowDescription;
                else
                    fVM.ShowImage = !fVM.ShowImage;

            }
            itemsViewModelWorkaround.FileVMsWA.UpdateRow(fVM);
        }
    }

}
