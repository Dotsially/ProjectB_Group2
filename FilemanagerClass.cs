using System;
using System.IO;

namespace ProjectB_Group2
{
    public class Filemanager
    {
        public static string jsondoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string jsonpathread(string x)
        {
            return File.ReadAllText(Path.Combine(jsondoc, @"GitHub\ProjectB_Group2\" + x));
        }
        public static string jsonpathwrite(string x)
        {
            return Path.Combine(jsondoc, @"GitHub\ProjectB_Group2\" + x);
        }
    }
}
