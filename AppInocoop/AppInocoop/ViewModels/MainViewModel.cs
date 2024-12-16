using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppInocoop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IBluetoothService _bluetoothService;
        private string _statusMessage;
        private CancellationTokenSource _cancellationTokenSource;

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public ICommand ConnectCommand { get; }

        public MainViewModel(IBluetoothService bluetoothService)
        {
            _bluetoothService = bluetoothService;
            ConnectCommand = new Command<string>(async (deviceId) => await ConnectToBluetoothAsync(deviceId));
        }

        private async Task ConnectToBluetoothAsync(string deviceId)
        {
            if (_bluetoothService.IsConnected)
            {
                StatusMessage = "Already connected!";
                return;
            }

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await _bluetoothService.ConnectToScoreBoardAsync(deviceId, _cancellationTokenSource.Token);
                StatusMessage = "Connected!";
            }
            catch (OperationCanceledException)
            {
                StatusMessage = "Connection canceled.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Connection failed: {ex.Message}";
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}