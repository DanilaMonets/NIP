using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace httpError
{
    /// <summary>
    /// Represents static class Logger
    /// </summary>
    public static class Logger
    {  
        /// <summary>
        /// Static list of error's code and list of dates
        /// </summary>
        private static SortedList<int, List<DateTime>> log;
        private const string PATH = "log.txt";

        /// <summary>
        /// Static basic constructor
        /// </summary>
        static Logger()
        {
            log = new SortedList<int, List<DateTime>>();
        }

        /// <summary>
        /// Gets variable log
        /// </summary>
        public static SortedList<int, List<DateTime>> Log
        {
            get
            {
                return log;
            }
        }

        /// <summary>
        /// Adds pair of key and time to log
        /// </summary>
        /// <param name="key"></param>
        /// <param name="time"></param>
        public static void AddLog(int key, DateTime time)
        {
            if (log.Keys.Contains(key))
            {
                int index = log.Keys.IndexOf(key);
                log.Values[index].Add(time);
            }
            else
            {
                List<DateTime> buffer = new List<DateTime>() { time };
                log.Add(key, buffer);
            }
            MakeALog(PATH);
        }

        /// <summary>
        /// Loads log in file
        /// </summary>
        /// <param name="filename"></param>
        private static void MakeALog(string filename)
        {
            string[] strArr = new string[log.Keys.Count];
            List<List<string>> str = new List<List<string>>();
           
            for (int i = 0; i < log.Keys.Count; ++i)
            {
                str.Add(new List<string>());
                str[i].Add($"#{log.Keys[i]}");
                for (int j = 0; j < log.Values[i].Count; ++j)
                {

                    str[i].Add($"\t{log.Values[i][j].ToString()}");
                }
                str[i].Add("\n");
                strArr[i] = string.Join("\n", str[i].ToArray());
            }
            string result = string.Join("\n", strArr);

            File.WriteAllText(filename, result);
        }
    }
}
