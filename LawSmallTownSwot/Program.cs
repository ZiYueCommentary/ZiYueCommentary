using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace LawSmallTownSwot
{
    public struct LawFramework
    {
        public string Volume; // 编
        public string Chapter; // 章
        public string Section; // 节
        public string Item; // 条
        public string Title; // 标题
        public string Description; // 描述
    }

    public class Program
    {
        public static List<LawFramework> law = new List<LawFramework>();
        public static Manager manager;
        static SQLiteConnection laws;// = new SQLiteConnection("Data Source=laws.db");
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            manager = new Manager();
            Application.Run(manager);
            return;
            laws.Open();
            try
            {
                switch (args[0])
                {
                    case "lr":
                        IEnumerable<string> lines = File.ReadLines(args[2]);
                        SQLiteCommand cmd = new SQLiteCommand(laws);
                        cmd.CommandText = $"create table {args[1]}(volume text, chapter text, section text, item text, title text, description text);";
                        cmd.ExecuteNonQuery();
                        bool isItem = false;
                        LawFramework law = new LawFramework();
                        foreach (string line in lines)
                        {
                            string trimLine = line.Trim();
                            if (Regex.IsMatch(trimLine, "第.*编　.*"))
                            {
                                law.Volume = trimLine;
                                continue;
                            }
                            if (Regex.IsMatch(trimLine, "第.*章　.*"))
                            {
                                law.Chapter = trimLine;
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
                                SQLiteCommand row = new SQLiteCommand(laws);
                                row.CommandText = $"INSERT INTO {args[1]}(volume, chapter, section, item, title, description) VALUES('{law.Volume}', '{law.Chapter}', '{law.Section}', '{law.Item}', '{law.Title}', '{law.Description}');";
                                row.ExecuteNonQuery();
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
                        break;
                    case "ss":
                        SQLiteCommand cmd1 = new SQLiteCommand(laws);
                        cmd1.CommandText = $"select * from {args[1]} where description like '%{args[2]}%'";
                        SQLiteDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("第" + reader.StepCount + "条结果");
                            Console.WriteLine("编：" + reader[0].ToString());
                            Console.WriteLine("章：" + reader[1].ToString());
                            Console.WriteLine("节：" + reader[2].ToString());
                            Console.WriteLine("条： " + reader[3].ToString());
                            Console.WriteLine("标题：" + reader[4].ToString());
                            Console.WriteLine("内容：" + reader[5].ToString());
                            Console.WriteLine();
                        }
                        reader.Close();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("使用手册：");
                Console.WriteLine("录入：lr [数据库名] [文件路径]");
                Console.WriteLine("搜索：ss [数据库名] [关键词]");
            }
        }
    }
}
