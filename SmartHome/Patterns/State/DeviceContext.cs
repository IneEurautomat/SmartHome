namespace SmartHome.Patterns.State
{
    public class DeviceContext
    {
        public IDeviceState State { get; set; }
        public string DeviceName { get; }

        public DeviceContext(string deviceName, IDeviceState initialState)
        {
            DeviceName = deviceName;
            State = initialState;
        }

        public void Request()
        {
            State.Handle(this);
        }
        public void SetState(IDeviceState newState)
        {
            State = newState;
        }
    }
}
