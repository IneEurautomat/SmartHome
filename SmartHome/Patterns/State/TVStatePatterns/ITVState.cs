using SmartHome.Models;
using SmartHome.Services;

namespace SmartHome.Patterns.State.TVStatePatterns
{
    public interface ITVState
    {
        void Handle(TV context);
    }
}
