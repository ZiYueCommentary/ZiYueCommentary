namespace MapCreator
{
    public partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptionsDefaultEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptionsPlaceDoors = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptionsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuOptionsMapSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptionsMapInformations = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptionsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuOptionsCameraSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolsMapGenerator = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpManual = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            resources.ApplyResources(this.StatusStrip, "StatusStrip");
            this.StatusStrip.Name = "StatusStrip";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuOptions,
            this.MenuTools,
            this.MenuHelp});
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            this.MenuStrip.Name = "MenuStrip";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNew,
            this.MenuFileOpen,
            this.MenuFileSeparator1,
            this.MenuFileSave,
            this.MenuFileSaveAs,
            this.MenuFileSeparator2,
            this.MenuFileQuit});
            this.MenuFile.Name = "MenuFile";
            resources.ApplyResources(this.MenuFile, "MenuFile");
            // 
            // MenuFileNew
            // 
            this.MenuFileNew.Name = "MenuFileNew";
            resources.ApplyResources(this.MenuFileNew, "MenuFileNew");
            this.MenuFileNew.MouseEnter += new System.EventHandler(this.EventMenuFileNewMouseEnter);
            this.MenuFileNew.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuFileOpen
            // 
            this.MenuFileOpen.Name = "MenuFileOpen";
            resources.ApplyResources(this.MenuFileOpen, "MenuFileOpen");
            this.MenuFileOpen.MouseEnter += new System.EventHandler(this.EventMenuFileOpenMouseEnter);
            this.MenuFileOpen.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuFileSeparator1
            // 
            this.MenuFileSeparator1.Name = "MenuFileSeparator1";
            resources.ApplyResources(this.MenuFileSeparator1, "MenuFileSeparator1");
            // 
            // MenuFileSave
            // 
            this.MenuFileSave.Name = "MenuFileSave";
            resources.ApplyResources(this.MenuFileSave, "MenuFileSave");
            this.MenuFileSave.MouseEnter += new System.EventHandler(this.EventMenuFileSaveMouseEnter);
            this.MenuFileSave.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuFileSaveAs
            // 
            this.MenuFileSaveAs.Name = "MenuFileSaveAs";
            resources.ApplyResources(this.MenuFileSaveAs, "MenuFileSaveAs");
            this.MenuFileSaveAs.MouseEnter += new System.EventHandler(this.EventMenuFileSaveAsMouseEnter);
            this.MenuFileSaveAs.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuFileSeparator2
            // 
            this.MenuFileSeparator2.Name = "MenuFileSeparator2";
            resources.ApplyResources(this.MenuFileSeparator2, "MenuFileSeparator2");
            // 
            // MenuFileQuit
            // 
            this.MenuFileQuit.Name = "MenuFileQuit";
            resources.ApplyResources(this.MenuFileQuit, "MenuFileQuit");
            this.MenuFileQuit.Click += new System.EventHandler(this.EventMenuFileQuitClick);
            this.MenuFileQuit.MouseEnter += new System.EventHandler(this.EventMenuFileQuitMouseEnter);
            this.MenuFileQuit.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuOptions
            // 
            this.MenuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOptionsDefaultEvents,
            this.MenuOptionsPlaceDoors,
            this.MenuOptionsSeparator1,
            this.MenuOptionsMapSettings,
            this.MenuOptionsMapInformations,
            this.MenuOptionsSeparator2,
            this.MenuOptionsCameraSettings});
            this.MenuOptions.Name = "MenuOptions";
            resources.ApplyResources(this.MenuOptions, "MenuOptions");
            // 
            // MenuOptionsDefaultEvents
            // 
            this.MenuOptionsDefaultEvents.Name = "MenuOptionsDefaultEvents";
            resources.ApplyResources(this.MenuOptionsDefaultEvents, "MenuOptionsDefaultEvents");
            this.MenuOptionsDefaultEvents.Click += new System.EventHandler(this.EventMenuOptionsDefaultEventsClick);
            this.MenuOptionsDefaultEvents.MouseEnter += new System.EventHandler(this.EventMenuOptionsDefaultEventsMouseEnter);
            this.MenuOptionsDefaultEvents.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuOptionsPlaceDoors
            // 
            this.MenuOptionsPlaceDoors.Name = "MenuOptionsPlaceDoors";
            resources.ApplyResources(this.MenuOptionsPlaceDoors, "MenuOptionsPlaceDoors");
            this.MenuOptionsPlaceDoors.Click += new System.EventHandler(this.EventMenuOptionsPlaceDoorsClick);
            this.MenuOptionsPlaceDoors.MouseEnter += new System.EventHandler(this.EventMenuOptionsPlaceDoorsMouseEnter);
            this.MenuOptionsPlaceDoors.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuOptionsSeparator1
            // 
            this.MenuOptionsSeparator1.Name = "MenuOptionsSeparator1";
            resources.ApplyResources(this.MenuOptionsSeparator1, "MenuOptionsSeparator1");
            // 
            // MenuOptionsMapSettings
            // 
            this.MenuOptionsMapSettings.Name = "MenuOptionsMapSettings";
            resources.ApplyResources(this.MenuOptionsMapSettings, "MenuOptionsMapSettings");
            this.MenuOptionsMapSettings.MouseEnter += new System.EventHandler(this.EventMenuButtonsMouseEnter);
            this.MenuOptionsMapSettings.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuOptionsMapInformations
            // 
            this.MenuOptionsMapInformations.Name = "MenuOptionsMapInformations";
            resources.ApplyResources(this.MenuOptionsMapInformations, "MenuOptionsMapInformations");
            this.MenuOptionsMapInformations.MouseEnter += new System.EventHandler(this.EventMenuButtonsMouseEnter);
            this.MenuOptionsMapInformations.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuOptionsSeparator2
            // 
            this.MenuOptionsSeparator2.Name = "MenuOptionsSeparator2";
            resources.ApplyResources(this.MenuOptionsSeparator2, "MenuOptionsSeparator2");
            // 
            // MenuOptionsCameraSettings
            // 
            this.MenuOptionsCameraSettings.Name = "MenuOptionsCameraSettings";
            resources.ApplyResources(this.MenuOptionsCameraSettings, "MenuOptionsCameraSettings");
            this.MenuOptionsCameraSettings.MouseLeave += new System.EventHandler(this.EventMenuButtonsMouseLeave);
            // 
            // MenuTools
            // 
            this.MenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolsMapGenerator});
            this.MenuTools.Name = "MenuTools";
            resources.ApplyResources(this.MenuTools, "MenuTools");
            // 
            // MenuToolsMapGenerator
            // 
            this.MenuToolsMapGenerator.Name = "MenuToolsMapGenerator";
            resources.ApplyResources(this.MenuToolsMapGenerator, "MenuToolsMapGenerator");
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpManual,
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            resources.ApplyResources(this.MenuHelp, "MenuHelp");
            // 
            // MenuHelpManual
            // 
            this.MenuHelpManual.Name = "MenuHelpManual";
            resources.ApplyResources(this.MenuHelpManual, "MenuHelpManual");
            this.MenuHelpManual.Click += new System.EventHandler(this.EventMenuHelpManualClick);
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            resources.ApplyResources(this.MenuHelpAbout, "MenuHelpAbout");
            this.MenuHelpAbout.Click += new System.EventHandler(this.EventMenuHelpAboutClick);
            // 
            // Window
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventWindowClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EventWindowKeyDown);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip StatusStrip;
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        public System.Windows.Forms.MenuStrip MenuStrip;
        public System.Windows.Forms.ToolStripMenuItem MenuFile;
        public System.Windows.Forms.ToolStripMenuItem MenuOptions;
        public System.Windows.Forms.ToolStripMenuItem MenuFileNew;
        public System.Windows.Forms.ToolStripMenuItem MenuFileOpen;
        public System.Windows.Forms.ToolStripSeparator MenuFileSeparator1;
        public System.Windows.Forms.ToolStripMenuItem MenuFileSave;
        public System.Windows.Forms.ToolStripMenuItem MenuFileSaveAs;
        public System.Windows.Forms.ToolStripSeparator MenuFileSeparator2;
        public System.Windows.Forms.ToolStripMenuItem MenuFileQuit;
        public System.Windows.Forms.ToolStripMenuItem MenuTools;
        public System.Windows.Forms.ToolStripMenuItem MenuToolsMapGenerator;
        public System.Windows.Forms.ToolStripMenuItem MenuHelp;
        public System.Windows.Forms.ToolStripMenuItem MenuHelpManual;
        public System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        public System.Windows.Forms.ToolStripMenuItem MenuOptionsDefaultEvents;
        public System.Windows.Forms.ToolStripMenuItem MenuOptionsPlaceDoors;
        public System.Windows.Forms.ToolStripMenuItem MenuOptionsMapSettings;
        public System.Windows.Forms.ToolStripMenuItem MenuOptionsMapInformations;
        public System.Windows.Forms.ToolStripSeparator MenuOptionsSeparator1;
        public System.Windows.Forms.ToolStripSeparator MenuOptionsSeparator2;
        public System.Windows.Forms.ToolStripMenuItem MenuOptionsCameraSettings;
    }
}
