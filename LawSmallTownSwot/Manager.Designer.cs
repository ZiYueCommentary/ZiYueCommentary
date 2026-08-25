namespace LawSmallTownSwot
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.volumes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chapters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sections = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.items = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sreachgroupbox = new System.Windows.Forms.GroupBox();
            this.checkBoxvolume = new System.Windows.Forms.CheckBox();
            this.checkBoxchapter = new System.Windows.Forms.CheckBox();
            this.checkBoxSection = new System.Windows.Forms.CheckBox();
            this.checkBoxitem = new System.Windows.Forms.CheckBox();
            this.checkBoxtitle = new System.Windows.Forms.CheckBox();
            this.checkBoxdesc = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.sreachgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.sreachgroupbox);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 428);
            this.splitContainer1.SplitterDistance = 571;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(571, 428);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(563, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.volumes,
            this.chapters,
            this.sections,
            this.items,
            this.title,
            this.descriptions});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(557, 396);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // volumes
            // 
            this.volumes.Text = "编";
            // 
            // chapters
            // 
            this.chapters.Text = "章";
            // 
            // sections
            // 
            this.sections.Text = "节";
            // 
            // items
            // 
            this.items.Text = "条";
            // 
            // title
            // 
            this.title.Text = "标题";
            this.title.Width = 80;
            // 
            // descriptions
            // 
            this.descriptions.Text = "正文";
            this.descriptions.Width = 173;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(563, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "录入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sreachgroupbox
            // 
            this.sreachgroupbox.Controls.Add(this.checkBoxdesc);
            this.sreachgroupbox.Controls.Add(this.checkBoxtitle);
            this.sreachgroupbox.Controls.Add(this.checkBoxitem);
            this.sreachgroupbox.Controls.Add(this.checkBoxSection);
            this.sreachgroupbox.Controls.Add(this.checkBoxchapter);
            this.sreachgroupbox.Controls.Add(this.checkBoxvolume);
            this.sreachgroupbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sreachgroupbox.Location = new System.Drawing.Point(13, 102);
            this.sreachgroupbox.Name = "sreachgroupbox";
            this.sreachgroupbox.Size = new System.Drawing.Size(200, 68);
            this.sreachgroupbox.TabIndex = 2;
            this.sreachgroupbox.TabStop = false;
            this.sreachgroupbox.Text = "搜索范围";
            // 
            // checkBoxvolume
            // 
            this.checkBoxvolume.AutoSize = true;
            this.checkBoxvolume.Location = new System.Drawing.Point(19, 20);
            this.checkBoxvolume.Name = "checkBoxvolume";
            this.checkBoxvolume.Size = new System.Drawing.Size(36, 16);
            this.checkBoxvolume.TabIndex = 0;
            this.checkBoxvolume.Text = "编";
            this.checkBoxvolume.UseVisualStyleBackColor = true;
            // 
            // checkBoxchapter
            // 
            this.checkBoxchapter.AutoSize = true;
            this.checkBoxchapter.Location = new System.Drawing.Point(61, 20);
            this.checkBoxchapter.Name = "checkBoxchapter";
            this.checkBoxchapter.Size = new System.Drawing.Size(36, 16);
            this.checkBoxchapter.TabIndex = 1;
            this.checkBoxchapter.Text = "章";
            this.checkBoxchapter.UseVisualStyleBackColor = true;
            // 
            // checkBoxSection
            // 
            this.checkBoxSection.AutoSize = true;
            this.checkBoxSection.Location = new System.Drawing.Point(103, 20);
            this.checkBoxSection.Name = "checkBoxSection";
            this.checkBoxSection.Size = new System.Drawing.Size(36, 16);
            this.checkBoxSection.TabIndex = 2;
            this.checkBoxSection.Text = "节";
            this.checkBoxSection.UseVisualStyleBackColor = true;
            // 
            // checkBoxitem
            // 
            this.checkBoxitem.AutoSize = true;
            this.checkBoxitem.Location = new System.Drawing.Point(145, 20);
            this.checkBoxitem.Name = "checkBoxitem";
            this.checkBoxitem.Size = new System.Drawing.Size(36, 16);
            this.checkBoxitem.TabIndex = 3;
            this.checkBoxitem.Text = "条";
            this.checkBoxitem.UseVisualStyleBackColor = true;
            // 
            // checkBoxtitle
            // 
            this.checkBoxtitle.AutoSize = true;
            this.checkBoxtitle.Location = new System.Drawing.Point(49, 42);
            this.checkBoxtitle.Name = "checkBoxtitle";
            this.checkBoxtitle.Size = new System.Drawing.Size(48, 16);
            this.checkBoxtitle.TabIndex = 4;
            this.checkBoxtitle.Text = "标题";
            this.checkBoxtitle.UseVisualStyleBackColor = true;
            // 
            // checkBoxdesc
            // 
            this.checkBoxdesc.AutoSize = true;
            this.checkBoxdesc.Checked = true;
            this.checkBoxdesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxdesc.Location = new System.Drawing.Point(103, 42);
            this.checkBoxdesc.Name = "checkBoxdesc";
            this.checkBoxdesc.Size = new System.Drawing.Size(48, 16);
            this.checkBoxdesc.TabIndex = 5;
            this.checkBoxdesc.Text = "正文";
            this.checkBoxdesc.UseVisualStyleBackColor = true;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Manager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.sreachgroupbox.ResumeLayout(false);
            this.sreachgroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ColumnHeader chapters;
        public System.Windows.Forms.ColumnHeader sections;
        public System.Windows.Forms.ColumnHeader items;
        public System.Windows.Forms.ColumnHeader title;
        public System.Windows.Forms.ColumnHeader descriptions;
        public System.Windows.Forms.ColumnHeader volumes;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox sreachgroupbox;
        private System.Windows.Forms.CheckBox checkBoxdesc;
        private System.Windows.Forms.CheckBox checkBoxtitle;
        private System.Windows.Forms.CheckBox checkBoxitem;
        private System.Windows.Forms.CheckBox checkBoxSection;
        private System.Windows.Forms.CheckBox checkBoxchapter;
        private System.Windows.Forms.CheckBox checkBoxvolume;
    }
}