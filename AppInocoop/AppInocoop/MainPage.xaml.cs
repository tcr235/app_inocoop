using AppInocoop.ViewModels;

namespace AppInocoop
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(DependencyService.Get<IBluetoothService>());
        }
    }

}
