using SmartHome.Models;
using SmartHome.Services;

namespace SmartHome.Patterns.State
{
    public interface ITVState
    {
        void Handle(TV context);
    }
}
