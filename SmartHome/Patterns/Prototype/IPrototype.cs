namespace SmartHome.Patterns.Prototype
{
    public interface IPrototype<T>
    {
        T Clone();
    }
}
