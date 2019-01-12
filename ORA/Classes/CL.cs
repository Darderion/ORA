using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    class CL
    {
        //Class for constants
        
        public const int PlayButton = 0;
        public const int MapsButton = 1;
        public const int OptionsButton = 2;
        public const int ExitButton = 3;
        public const int MenuButtons = 4;

        public const int LoginMenuButtonPlay = 0;
        public const int LoginMenuButtonSettings = 1;
        public const int LoginMenuButtonExit = 2;
        public const int LoginMenuButtons = 3;

        public const string FolderImages = "Images/";

        public static readonly string[] LoginMenuButtonsNames = {
            "LoginMenuPlayButton",
            "LoginMenuSettingsButton",
            "LoginMenuExitButton"
        };
    }
}
