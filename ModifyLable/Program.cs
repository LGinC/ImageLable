using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModifyLable
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine(args[0]);
            DirectoryInfo intxt = new DirectoryInfo(args[0]);
            IEnumerable<FileInfo> outtxts = (intxt.GetFiles().Where(s => s.Extension.EndsWith("txt") || s.Extension.EndsWith("TXT")));
            foreach (var item in outtxts)
            {
                string[] contents = File.ReadAllLines(item.FullName);
                List<string> written = new List<string>();
                for (int i = 0; i < contents.Length; i++)
                {
                    if (contents[i]=="")
                    {
                        break;
                    }
                    if (i % 2 == 1)
                    {
                        written.Add(contents[i]);
                    }
                }
                File.WriteAllLines(item.FullName, new string[]{ written.Count.ToString()});
                File.AppendAllLines(item.FullName, written);
            }
        }
    }
}
