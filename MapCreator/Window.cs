using MapCreator.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MapCreator
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        /*
         * Naming Rules:
         *     Event + { Element Name } + { Event Type }
         * 
         * For example, "About..." button are clicked:
         *     EventMenuHelpAboutClick
         */

        private void EventMenuHelpManualClick(object sender, EventArgs e)
        {
            Process.Start("https://wiki.ziyuesinicization.site/index.php?title=Map_Creator_Manual");
        }

        private void EventMenuHelpAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show("SCP - Containment Breach Map Creator v3.0\nMade by ZiYueCommentary.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EventWindowKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    EventMenuHelpManualClick(sender, e);
                    break;
                case Keys.F2:
                    EventMenuHelpAboutClick(sender, e);
                    break;
                case Keys.Escape:
                    EventMenuFileQuitClick(sender, e);
                    break;
                case Keys.N:
                    if (e.Modifiers.CompareTo(Keys.Control) == 0) EventMenuFileNewClick(sender, e);
                    break;
            }
        }

        private void EventMenuFileQuitClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Settings.SettingsSaving();
                Environment.Exit(0);
            }
            if (e is FormClosingEventArgs window) 
            {
                window.Cancel = true;
            }
        }

        private void EventMenuFileNewMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Create a blank map.";
        }

        private void EventMenuButtonsMouseLeave(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "";
        }

        private void EventMenuFileOpenMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Open a map file.";
        }

        private void EventMenuFileSaveMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Save current changes for map.";
        }

        private void EventMenuFileSaveAsMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Save current changes in a new map.";
        }

        private void EventMenuFileQuitMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Close the Map Creator.";
        }

        private void EventWindowClosing(object sender, FormClosingEventArgs e)
        {
            EventMenuFileQuitClick(sender, e);
        }

        private void EventMenuOptionsDefaultEventsMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Set the event for the rooms by default.";
        }

        private void EventMenuOptionsPlaceDoorsMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Place adjacent doors in 3D view.";
        }

        private void EventMenuOptionsMapInformationMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Edit Author and Description for the map.";
        }

        private void EventMenuOptionsMapSettingsMouseEnter(object sender, EventArgs e)
        {
            Program.instance.StatusLabel.Text = "Edit Zone Transition for the map.";
        }

        private void EventMenuFileNewClick(object sender, EventArgs e)
        {
        }
    }
}
