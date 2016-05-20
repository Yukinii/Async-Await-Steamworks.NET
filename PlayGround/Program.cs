using System;
using System.Timers;

namespace PlayGround
{
    class Program
    {
        public static Timer Timer = new Timer(100);
        static void Main(string[] args)
        {
            SteamManager.Instance.GetWorkshopStuff();
            Timer.Elapsed += (sender, eventArgs) => SteamManager.Instance.Update();
            Timer.Start();

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
