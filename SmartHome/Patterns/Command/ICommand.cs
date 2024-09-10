using SmartHome.Models;

namespace SmartHome.Patterns.Command
{
    public interface ICommand
    {
        void Execute();
    }
    public interface ICommand<T>
    {
        void Execute(T device);
    }
}
