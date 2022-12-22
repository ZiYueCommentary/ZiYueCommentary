using System.Collections.Generic;
using System.Configuration;

namespace MapCreator.Properties 
{
    public sealed partial class Settings 
    {
        public static new void SettingsLoaded() {
            Program.instance.MenuOptionsDefaultEvents.Checked = Default.DefaultEvents;
            Program.instance.MenuOptionsPlaceDoors.Checked = Default.PlaceDoors;
        }

        public static new void SettingsSaving() {
            Default.DefaultEvents = Program.instance.MenuOptionsDefaultEvents.Checked;
            Default.PlaceDoors = Program.instance.MenuOptionsPlaceDoors.Checked;
            Default.Save();
        }
    }
}
