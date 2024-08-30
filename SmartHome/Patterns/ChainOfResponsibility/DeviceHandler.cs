namespace SmartHome.Patterns.ChainOfResponsibility
{
    public abstract class DeviceHandler
    {
        protected DeviceHandler _next;

        public void SetNext(DeviceHandler next)
        {
            _next = next;
        }

        public abstract void HandleRequest(string request);
    }
}
