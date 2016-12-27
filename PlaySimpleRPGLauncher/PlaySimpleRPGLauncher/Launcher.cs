using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PlaySimpleRPGLauncher
{
    class Launcher
    {
        public static void PlayGame(string gamename_exe)
        {
            //Start game by the passed gamename.exe
            Process.Start(gamename_exe);

            //Close this Launcher Application
            Environment.Exit(0);
        }

        public static void LaunchWebsite(string url)
        {
            //Opens the devault browser tap with the given url
            Process.Start(url);
        }
    }
}
