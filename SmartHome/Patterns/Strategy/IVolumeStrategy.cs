using SmartHome.Models;

namespace SmartHome.Patterns.Strategy
{
    //STRATEGY 
    //-------------------------------------------------------------------

    //Strategy Interface
    public interface IVolumeStrategy
    {
        void AdjustVolume(TV tv);
    }


    // Concrete Strategies
    public class MovieMode : IVolumeStrategy
    {
        public void AdjustVolume(TV tv)
        {
            Console.WriteLine("Adjusting volume for Film Mode: Enhancing dialog clarity.");
            // Pas het volume aan voor Film Mode
        }
    }

    public class MusicMode : IVolumeStrategy
    {
        public void AdjustVolume(TV tv)
        {
            Console.WriteLine("Adjusting volume for Music Mode: Enhancing sound clarity and volume.");
            // Pas het volume aan voor Music Mode
        }
    }

    public class SportMode : IVolumeStrategy
    {
        public void AdjustVolume(TV tv)
        {
            Console.WriteLine("Adjusting volume for Sport Mode: Increasing intensity.");
            // Pas het volume aan voor Sport Mode
        }
    }

    public class NightMode : IVolumeStrategy
    {
        public void AdjustVolume(TV tv)
        {
            Console.WriteLine("Adjusting volume for Night Mode: Lowering volume.");
            // Pas het volume aan voor Night Mode
        }
    }
}
