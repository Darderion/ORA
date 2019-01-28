using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    static class CL
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
        public const int LoginSettingsButtonStorage = 3;
        public const int LoginSettingsButtonResolution = 4;
        public const int LoginSettingsButtonBack = 5;
        public const int LoginMenuButtons = 6;

        public const int SettingsPauseBeforeText = 0;
        public const int SettingsIgnoreSpecialSymbols = 1;
        public const int SettingsIgnoreUpperCase = 2;
        public const int SettingsIgnoreSpaces = 3;
        public const int SettingsButtons = 4;

        public const int MinimalWidth = 800;
        public const int MinimalHeight = 600;

        public const string DataFolder = "Data/";
        public const string FolderImages = DataFolder + "Images/";
        public const string StorageType = "$<StorageType>";
        public const string DefaultSettingsFileName = "Settings.DIO";
        public const string MapsFolder = DataFolder + "Maps/";
        public const string VideoFolder = DataFolder + "Videos/";
        public const string ThumbnailFolder = DataFolder + "Thumbnails/";
        public const string Extension = ".ORA";

        public static readonly string[] LoginMenuButtonsNames = {
            "LoginMenuPlayButton",
            "LoginMenuSettingsButton",
            "LoginMenuExitButton",
            "LoginSettingsButtonStorage"+StorageType,
            "LoginSettingsButtonResolution",
            "LoginSettingsButtonBack"
        };

        public static readonly string LockedMap = "TheLock";
        public static readonly string NoMap = "None";
    }
}
