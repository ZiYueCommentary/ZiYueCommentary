using System.Text;

namespace System.Ini
{
    class IniReader
    {
        private IniReader() { }

        protected static Dictionary<string, Dictionary<string, string>> bufferMap = new();

        public static void WriteBuffer(string path)
        {
            try { IniReader.bufferMap.Remove(path); } catch (Exception) { }
            Dictionary<string, string> bufferMap = new();
            StreamReader sr = new(path);
            StringBuilder builder = new();
            string line, section = null;
            while ((line = sr.ReadLine()) != null)
            {
                builder.Append(line);
                if (builder[0] == '[' & builder[^1] == ']')
                {
                    builder.Remove(0, 1).Remove(builder.Length - 1, 1);
                    section = builder.ToString();
                }
                if (line.IndexOf('=') != -1)
                {
                    if (section == null) continue;
                    string key = line[..(line.IndexOf('=') - 1)];
                    builder.Remove(0, line.IndexOf('=') + 1);
                    if (builder[0] == ' ') builder.Remove(0, 1);
                    string content = builder.ToString();
                    bufferMap[section + "," + key] = content;
                }
                builder.Clear();
            }
            IniReader.bufferMap[path] = bufferMap;
        }

        public static void ClearBuffer(string path)
        {
            bufferMap.Remove(path);
        }

        public static void ClearBuffer()
        {
            bufferMap.Clear();
        }

        public static string? GetContent(string path, string section, string key, bool allowBuffer = true)
        {
            return GetContent(path, section, key, null, allowBuffer);
        }

        public static string? GetContent(string path, string section, string key, string defaultValue = null, bool allowBuffer = true)
        {
            string result = defaultValue;
            try
            {
                if (allowBuffer) result = bufferMap[path][section + "," + key];
            }
            catch (Exception) { }
            if (result == null)
            {
                try
                {
                    StreamReader sr = new(path);
                    StringBuilder builder = new();
                    string line, section1 = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        builder.Append(line);
                        if (builder[0] == '[' & builder[^1] == ']')
                        {
                            builder.Remove(0, 1).Remove(builder.Length - 1, 1);
                            section1 = builder.ToString();
                        }
                        if (line.IndexOf('=') != -1)
                        {
                            if (section1 == null) continue;
                            string key1 = line[..(line.IndexOf('=') - 1)];
                            builder.Remove(0, line.IndexOf('=') + 1);
                            if (builder[0] == ' ') builder.Remove(0, 1);
                            string content = builder.ToString();
                            if (key.Equals(key1) && section.Equals(section1)) return content;
                        }
                        builder.Clear();
                    }
                }
                catch (Exception)
                {
                    return defaultValue;
                }
            }
            return result;
        }
    }
}