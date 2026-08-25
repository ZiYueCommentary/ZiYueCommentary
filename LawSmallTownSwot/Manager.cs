using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace LawSmallTownSwot
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "录入...";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<string> lines = File.ReadLines(ofd.FileName);
                bool isItem = false;
                LawFramework law = new LawFramework();
                foreach (string line in lines)
                {
                    string trimLine = line.Trim();
                    if (Regex.IsMatch(trimLine, "第.*编　.*"))
                    {
                        law.Volume = trimLine;
                        law.Chapter = law.Section = "";
                        continue;
                    }
                    if (Regex.IsMatch(trimLine, "第.*章　.*"))
                    {
                        law.Chapter = trimLine;
                        law.Section = "";
                        continue;
                    }
                    if (Regex.IsMatch(trimLine, "第.*节　.*"))
                    {
                        law.Section = trimLine;
                        continue;
                    }
                    if (Regex.IsMatch(trimLine, "第.*条　.*"))
                    {
                        law.Item = trimLine.Substring(0, trimLine.IndexOf('　'));
                        law.Title = trimLine.Substring(trimLine.IndexOf('【') + 1, trimLine.IndexOf('】') - trimLine.IndexOf('【') - 1);
                        law.Description = trimLine.Substring(trimLine.IndexOf('】') + 1);
                        isItem = true;
                        continue;
                    }
                    if ((trimLine.Length == 0) && isItem)
                    {
                        Program.law.Add(law);
                        isItem = false;
                        continue;
                    }
                    if (isItem)
                    {
                        law.Description += "\n" + trimLine;
                        continue;
                    }

                    isItem = false;
                }
                
                foreach (var item in Program.law)
                {
                    Program.manager.listView1.Items.Add(new ListViewItem(new string[] {
            item.Volume,
            item.Chapter, item.Section, item.Item, item.Title, item.Description}, -1));
                }
                Program.manager.toolStripStatusLabel1.Text = $"录入完成！共录入{Program.law.Count}条。";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<LawFramework> law = from n in Program.law where n.Description.Contains(textBox1.Text) select n;
            Program.manager.listView1.Items.Clear();
            foreach (var item in law)
            {
                Program.manager.listView1.Items.Add(new ListViewItem(new string[] {
            item.Volume,
            item.Chapter, item.Section, item.Item, item.Title, item.Description}, -1));
            }
            Program.manager.toolStripStatusLabel1.Text = $"查找完成！共找到{law.Count()}条。";
        }
    }
}
