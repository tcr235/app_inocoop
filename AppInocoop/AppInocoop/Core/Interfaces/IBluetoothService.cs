namespace AppInocoop
{
    public interface IBluetoothService
    {
        Task ConnectToScoreBoardAsync(string deviceId, CancellationToken cancellationToken);
        Task DisconnectFromScoreBoardAsync();
        Task SendDataAsync(byte[] data);
        bool IsConnected { get; }
    }
}