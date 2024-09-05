using SmartHome.Models;

namespace SmartHome.Patterns.Visitor
{
    public interface IDeviceVisitor
    {
        void Visit(TV tv);
        void Visit(Light light);
        void Visit(Curtain curtain);
        void Visit(SecurityCamera securityCamera);
        void Visit(MusicPlayer musicPlayer);
        void Visit(OldThermostat thermostat);
        void Visit(OldThermostatAdapter oldThermostatAdapter);
        void Visit(CoffeeMachine coffeeMachine);

        //void Visit(WashingMachine washingMachine);
        //void Visit(Fireplace fireplace);
    }

}
