using System.Threading;

namespace StarWars
{
    internal class DemoHelper
    {
        public static void Pause(int secondsToPause = 7000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}