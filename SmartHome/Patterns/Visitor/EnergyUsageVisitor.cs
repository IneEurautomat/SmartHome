using SmartHome.Models;

namespace SmartHome.Patterns.Visitor
{
    public class EnergyUsageVisitor : IDeviceVisitor
    {
        public double TotalEnergyUsage { get; private set; } = 0;

        public void Visit(TV tv)
        {
            TotalEnergyUsage += tv.EnergyUsage;
        }

        public void Visit(Light light)
        {
            TotalEnergyUsage += light.EnergyUsage;
        }

        public void Visit(Curtain curtain)
        {
            TotalEnergyUsage += curtain.EnergyUsage;
        }

        public void Visit(SecurityCamera securityCamera)
        {
            TotalEnergyUsage += securityCamera.EnergyUsage;
        }

        public void Visit(MusicPlayer musicPlayer)
        {
            TotalEnergyUsage += musicPlayer.EnergyUsage;
        }

        public void Visit(CoffeeMachine coffeeMachine)
        {
            TotalEnergyUsage += coffeeMachine.EnergyUsage;
        }

        public void Visit(IndoorThermostat thermostat)
        {
            TotalEnergyUsage += thermostat.EnergyUsage;
        }

        //public void Visit(WashingMachine washingMachine)
        //{
        //    TotalEnergyUsage += washingMachine.EnergyUsage;
        //    Console.WriteLine($"Washing Machine energy usage: {washingMachine.EnergyUsage} kWh");
        //}

        //public void Visit(Fireplace fireplace)
        //{
        //    TotalEnergyUsage += fireplace.EnergyUsage;
        //    Console.WriteLine($"Fireplace energy usage: {fireplace.EnergyUsage} kWh");
        //}
    }

}
