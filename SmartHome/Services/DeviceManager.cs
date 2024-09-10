using SmartHome.Models;
using SmartHome.Patterns.Command;
using SmartHome.Patterns.Command.Commands;
using System.Collections.Generic;

namespace SmartHome.Services
{
    public class DeviceManager
    {
        private readonly Dictionary<string, IDevice> _devices = new Dictionary<string, IDevice>();
        private readonly Dictionary<string, RemoteControl<IDevice>> _remoteControls = new Dictionary<string, RemoteControl<IDevice>>();

        public void RegisterDevice(string deviceName, IDevice device)
        {
            if (!_devices.ContainsKey(deviceName))
            {
                _devices[deviceName] = device;
                var remoteControl = new RemoteControl<IDevice>();
                _remoteControls[deviceName] = remoteControl;

                // Voeg basiscommando's toe voor generieke apparaten
                remoteControl.SetCommand("TurnOn", new TurnOnCommand<IDevice>());
                remoteControl.SetCommand("TurnOff", new TurnOffCommand<IDevice>());
            }
        }

        public RemoteControl<IDevice> GetRemoteControl(string deviceName)
        {
            return _remoteControls.ContainsKey(deviceName) ? _remoteControls[deviceName] : null;
        }
    }
}
