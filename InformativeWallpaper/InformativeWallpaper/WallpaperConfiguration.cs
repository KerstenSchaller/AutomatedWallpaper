using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformativeWallpaper
{
    class WallpaperConfiguration
    {

        public WallPaperConfigurationValues config_values = new WallPaperConfigurationValues();
        private string config_file_path = "";
        private bool configedited = false;

        public WallpaperConfiguration()
        {
            string current_directory = Directory.GetCurrentDirectory();
            this.config_file_path = Path.Combine(current_directory, "WallPaperConfiguration.cfg");
            this.loadConfig();
        }


        /// <summary>
        /// Checks if a configuration exists 
        /// </summary>
        /// <returns>bool value to indicate wether configuration file exists in the working dir or not</returns>
        private bool checkIfConfigExists()
        {
            bool config_exists = File.Exists(config_file_path);
            return config_exists;
        }

        private void createConfig()
        {
            Serialization.WriteToXmlFile(config_file_path, config_values, false);
        }

        /// <summary>
        /// Loads a configuration from XML file
        /// </summary>
        /// <returns>object of WallPaperConfigurationValues</returns>
        public void loadConfig()
        {
            bool config_exists = checkIfConfigExists();
            if (config_exists)
            {
                this.config_values = Serialization.ReadFromXmlFile<WallPaperConfigurationValues>(config_file_path);
                WallPaperConfigurationValues new_config = new WallPaperConfigurationValues();
                if ((config_values.x_resolution == new_config.x_resolution) && (config_values.y_resolution == new_config.y_resolution))
                {
                    this.configedited = false;
                }
                else
                {
                    this.configedited = true;
                }
                
            }
            else
            {
                createConfig();
                configedited = false;

            }

        }
        

    }

    public class WallPaperConfigurationValues
    {
        public WallPaperConfigurationValues() { }
        public Int32 x_resolution = 1000;
        public Int32 y_resolution = 1000;
        public string ImageSourceFolder = @"C:\WallpaperImageSourceFolder";
        
    }
}
