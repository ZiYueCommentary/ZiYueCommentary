using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZiYue.Ini
{
    /// <summary>
    /// IniReader is a reader for ini files.
    /// </summary>
    class IniReader
    {
        private IniReader() { }

        protected static Dictionary<string, Dictionary<string, Dictionary<string, string>>> bufferMap = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

        public static void WriteBuffer(string path)
        {
            try { IniReader.bufferMap.Remove(path); } catch (Exception) { }
            Dictionary<string, Dictionary<string, string>> bufferMap = new Dictionary<string, Dictionary<string, string>>();
            StreamReader sr = new StreamReader(path);
            StringBuilder builder = new StringBuilder();
            string line, section = null;
            while ((line = sr.ReadLine()) != null)
            {
                builder.Append(line);
                if (builder[0] == '[' & builder[builder.Length - 1] == ']')
                {
                    builder.Remove(0, 1).Remove(builder.Length - 1, 1);
                    section = builder.ToString();
                }
                if (line.IndexOf('=') != -1)
                {
                    if (section == null) continue;
                    string key = line.Substring(0, line.IndexOf('=') - 1);
                    builder.Remove(0, line.IndexOf('=') + 1);
                    if (builder[0] == ' ') builder.Remove(0, 1);
                    string content = builder.ToString();
                    bufferMap[section][key] = content;
                }
                builder.Remove(0, builder.Length);
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

        public static string GetContent(string path, string section, string key, string defaultValue = "", bool allowBuffer = true)
        {
            string result = defaultValue;
            try
            {
                if (allowBuffer) result = bufferMap[path][section][key];
            }
            catch (Exception) { }
            if (result == null)
            {
                try
                {
                    StreamReader sr = new StreamReader(path);
                    StringBuilder builder = new StringBuilder();
                    string line, section1 = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        builder.Append(line);
                        if (builder[0] == '[' & builder[builder.Length - 1] == ']')
                        {
                            builder.Remove(0, 1).Remove(builder.Length - 1, 1);
                            section1 = builder.ToString();
                        }
                        if (line.IndexOf('=') != -1)
                        {
                            if (section1 == null) continue;
                            string key1 = line.Substring(0, line.IndexOf('=') - 1);
                            builder.Remove(0, line.IndexOf('=') + 1);
                            if (builder[0] == ' ') builder.Remove(0, 1);
                            string content = builder.ToString();
                            if (key.Equals(key1) && section.Equals(section1)) return content;
                        }
                        builder.Remove(0, builder.Length);
                    }
                }
                catch (Exception)
                {
                    return defaultValue;
                }
            }
            return result;
        }

        public static void SetBufferValue(string path, string section, string key, string value)
        {
            bufferMap[path][section][key] = value;
        }

        public static bool BufferSectionExist(string path, string section) 
        { 
            return bufferMap[path].ContainsKey(section);
        }

        public static bool BufferKeyExist(string path, string section, string key)
        {
            return bufferMap[path][section].ContainsKey(key);
        }
    }
}