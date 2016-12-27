using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PlaySimpleRPGLauncher
{
    /// <summary>
    /// Author: Nico Küchler 2016
    /// 
    /// Small background class to provide Methodes that can be called from the mainwindow buttons
    /// </summary>
    class Launcher
    {
        //Methode to start a given process by name.exe
        public static void PlayGame(string gamename_exe)
        {
            //Start game by the passed gamename.exe
            Process.Start(gamename_exe);

            //Close this Launcher Application
            Environment.Exit(0);
        }

        //Simple Methode to open the browser and launch a website
        public static void LaunchWebsite(string url)
        {
            //Opens the devault browser tap with the given url
            Process.Start(url);
        }
    }
}
