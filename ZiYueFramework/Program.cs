using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        foreach (string message in GetDataWithStatus())
        {
            Console.WriteLine(message);
        }
    }

    public static IEnumerable<string> GetDataWithStatus()
    {
        // 第一个 yield：提示正在获取数据
        yield return "正在获取...";

        // 模拟远程请求延迟（例如 2 秒）
        Thread.Sleep(2000);
        yield break;

        // 返回实际数据
        yield return "远程数据已获取";
    }
}