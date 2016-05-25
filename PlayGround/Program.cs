using System;

namespace PlayGround
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            SteamManager.Instance.Download();
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
