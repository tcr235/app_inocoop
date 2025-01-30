using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;

namespace AppInocoop
{
    public class BluetoothService : IBluetoothService
    {
        private readonly IBluetoothLE _bluetoothLE;
        private readonly IAdapter _adapter;
        private IDevice _device;

        public BluetoothService()
        {
            _bluetoothLE = CrossBluetoothLE.Current;
            _adapter = CrossBluetoothLE.Current.Adapter;
        }

        public bool IsConnected => _device != null && _device.State == DeviceState.Connected;

        public async Task ConnectToScoreBoardAsync(string deviceId, CancellationToken cancellationToken)
        {
            var devices = _adapter.GetSystemConnectedOrPairedDevices();
            _device = devices.FirstOrDefault(d => d.Name == deviceId);

            if (_device != null)
            {
                var connectParameters = new ConnectParameters(forceBleTransport: false);
                await _adapter.ConnectToDeviceAsync(_device, connectParameters, cancellationToken);
            }
            else
            {
                throw new Exception("Placar não encontrado.");
            }
        }

        public async Task DisconnectFromScoreBoardAsync()
        {
            if (_device != null)
            {
                await _adapter.DisconnectDeviceAsync(_device);
                _device = null;
            }
        }

        public async Task SendDataAsync(byte[] data)
        {
            if (_device != null)
            {
                var service = await _device.GetServiceAsync(Guid.Parse("0000FFE0-0000-1000-8000-00805F9B34FB"));
                var characteristic = await service.GetCharacteristicAsync(Guid.Parse("0000FFE1-0000-1000-8000-00805F9B34FB"));
                await characteristic.WriteAsync(data);
            }
            else
            {
                throw new Exception("Nenhum dispositivo conectado.");
            }
        }
    }
}