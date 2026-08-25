
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

class LogProcessor
{
    static void Main(string[] args)
    {
        string logDirectory = @"N:\Downloads\logs_6znh5"; // TODO: 修改为你的日志文件夹路径
        string[] logFiles = Directory.GetFiles(logDirectory, "*.log", SearchOption.TopDirectoryOnly);

        Regex logPattern = new Regex(@"\[\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\] INFO 俄罗斯轮盘开枪 - 调用者：.+?\(\d+\)，参数：\d+,(?<last>\d+)", RegexOptions.Compiled);

        List<ulong> extractedValues = new List<ulong>();

        foreach (var file in logFiles)
        {
            foreach (var line in File.ReadLines(file))
            {
                var match = logPattern.Match(line);
                if (match.Success)
                {
                    string lastParamStr = match.Groups["last"].Value;
                    if (ulong.TryParse(lastParamStr, out ulong lastParam))
                    {
                        extractedValues.Add(lastParam);
                        // Console.WriteLine($"提取参数：{lastParam} 来自文件：{Path.GetFileName(file)}");

                        // TODO: 将 lastParam 插入数据库
                        InsertToDatabase(lastParam);
                    }
                }
            }
        }

        Console.WriteLine($"共提取 {extractedValues.Count} 个参数。");
    }

    static void InsertToDatabase(ulong value)
    {
        using var conn =
            new MySqlConnection("server=localhost;user=root;password=123456;database=ziyuebot;charset=utf8mb4");
        conn.Open();
        ;
        using MySqlCommand update =
            new MySqlCommand(
                $"UPDATE revolver SET being_shot = being_shot + 1 WHERE userid = {value}",conn
                );
        update.ExecuteNonQuery();
    }
}
