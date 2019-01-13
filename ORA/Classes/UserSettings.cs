using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ORA
{
    public class UserSettings
    {
        public UserSettings()
        {
            resolutionWidth = Screen.PrimaryScreen.Bounds.Width;
            resolutionHeight = Screen.PrimaryScreen.Bounds.Height;
            isUsingDB = false;
        }

        public int resolutionWidth;
        public int resolutionHeight;
        public bool isUsingDB;

        public bool Save()
        {
            try
            {
                using (var sw = new StreamWriter(CL.DefaultSettingsFileName))
                {
                    var xm = new XmlSerializer(typeof(UserSettings));
                    xm.Serialize(sw, this);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Load()
        {
            try
            {
                using (var sr = new StreamReader(CL.DefaultSettingsFileName))
                {
                    var xm = new XmlSerializer(typeof(UserSettings));
                    UserSettings loadedSettings = (UserSettings)xm.Deserialize(sr);
                    if (loadedSettings != null)
                    {
                        resolutionWidth = loadedSettings.resolutionWidth;
                        resolutionHeight = loadedSettings.resolutionHeight;
                        isUsingDB = loadedSettings.isUsingDB;
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
            }
            return false;
        }
    }
}
