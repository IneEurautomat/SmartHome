namespace SmartHome.Patterns.State
{
    public interface IDeviceState
    {
        void Handle(DeviceContext context);
    }

}
