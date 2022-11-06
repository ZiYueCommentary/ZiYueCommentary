using System.Text;

namespace ZiYue
{
    class CommandParser
    {
        public static string[] Parse(string str, string split = " ", string ingoreSplit = "\"")
        {
            List<string> strings = new();
            StringBuilder builder = new(str);
            while (builder.ToString().IndexOf(split) != -1)
            {
                if (builder.ToString().StartsWith(ingoreSplit)) 
                {
                    builder.Remove(0, 1);
                    strings.Add(builder.ToString()[..builder.ToString().IndexOf(ingoreSplit)]);
                    builder.Remove(0, builder.ToString().IndexOf(ingoreSplit) + ingoreSplit.Length);
                }
                else
                {
                    strings.Add(builder.ToString()[0..builder.ToString().IndexOf(split)]);
                    builder.Remove(0, builder.ToString().IndexOf(split) + split.Length);
                }
            }
            if(builder.Length > 0) strings.Add(builder.ToString());
            return strings.ToArray();
        }
    }
}