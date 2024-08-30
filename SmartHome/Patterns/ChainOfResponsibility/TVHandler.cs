using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
    public class TVHandler : DeviceHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "TV")
            {
                Console.WriteLine("Handling request for TV");
            }
            else
            {
                _next?.HandleRequest(request);
            }
        }
    }
}
