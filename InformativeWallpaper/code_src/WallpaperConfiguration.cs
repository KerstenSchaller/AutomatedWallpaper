using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Serialization;

namespace InformativeWallpaper
{
    static class WallpaperConfiguration
    {

        static public WallPaperConfigurationValues config_values = new WallPaperConfigurationValues();
        static private string config_file_path = "";
        
        public static WallPaperConfigurationValues getWallpaperConfigurationValues()
        {
            string current_directory = Directory.GetCurrentDirectory();
            config_file_path = Path.Combine(current_directory, "WallPaperConfiguration.cfg");
            loadConfig();
            return config_values;
        }


        /// <summary>
        /// Checks if a configuration exists 
        /// </summary>
        /// <returns>bool value to indicate wether configuration file exists in the working dir or not</returns>
        private static bool checkIfConfigExists()
        {
            config_file_path = Path.Combine(Directory.GetCurrentDirectory(), "WallPaperConfiguration.cfg");
            bool config_exists = File.Exists(config_file_path);
            return config_exists;
        }

        private static void createConfig()
        {
            config_file_path = Path.Combine(Directory.GetCurrentDirectory(), "WallPaperConfiguration.cfg");
            Serialization.Serialization.WriteToXmlFile(config_file_path, config_values, false);
        }

        public static void saveNewConfig(WallPaperConfigurationValues config)
        {
            config_values = config;
            createConfig();
        }

        /// <summary>
        /// Loads a configuration from XML file
        /// </summary>
        /// <returns>object of WallPaperConfigurationValues</returns>
        private static void loadConfig()
        {
            bool config_exists = checkIfConfigExists();
            if (config_exists)
            {
                config_values = Serialization.Serialization.ReadFromXmlFile<WallPaperConfigurationValues>(config_file_path);
                WallPaperConfigurationValues new_config = new WallPaperConfigurationValues();
            }
            else
            {
                createConfig();
            }
        }
        

    }

    public class WallPaperConfigurationValues
    {
        public WallPaperConfigurationValues() { }
        public Int32 x_resolution_left_screen = 1000;
        public Int32 y_resolution_left_screen = 1000;
        public Int32 x_resolution_right_screen = 1000;
        public Int32 y_resolution_right_screen = 1000;
        public Int32 intervall_in_seconds = 15;
        public bool leftScreenStatic = false;
        public bool rightScreenStatic = false;
        public bool leftScreenComic = false;
        public bool rightScreenComic = false;
        public string leftScreenImageSource = Directory.GetCurrentDirectory();
        public string rightScreenImageSource = Directory.GetCurrentDirectory();
    }
}
