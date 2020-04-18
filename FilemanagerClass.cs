using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ProjectB_Group2
{
    public class Filemanager
    {
        static string jsonstring;
        //Read and Write json files.
        public static string jsondoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string jsonpathread(string x)
        {
            return File.ReadAllText(Path.Combine(jsondoc, @"Restaurant\json\" + x));
        }
        public static string jsonpathwrite(string x)
        {
            return Path.Combine(jsondoc, @"Restaurant\json\" + x);
        }

        static Dictionary<string, string> rootdic = new Dictionary<string, string>();
        public static void jsonfile(Dictionary<string, string> y, string z, string a, string b)
        {
            y.Add(a, b);
            jsonstring = JsonConvert.SerializeObject(y);
            File.WriteAllText(z, jsonstring);
        }


        //Create Restaurant folder.
        public static string RestaurantDirec()
        {
            return Path.Combine(jsondoc, "Restaurant");
        }

        //Create folder and Json files.
        public static string foldercreate(string x)
        {
            return Path.Combine(RestaurantDirec(), x);
        }
        public static string jsonfilecreate(string x)
        {
            return Path.Combine(foldercreate("json"), x);
        }

        public static void FileCreator(string x, string a , string b)
        {
            if (!File.Exists(x))
            {
                var myFile = File.Create(x);
                myFile.Close();
                jsonfile(rootdic, x, a, b);
            }

        }

        public static void FolderCreator(string x)
        {
            if (!Directory.Exists(x))
            {
                Directory.CreateDirectory(x);
            }
        }

        //Restaurant first time startup.
        public static void RestaurantSetup()
        {
            FolderCreator(RestaurantDirec());
            FolderCreator(foldercreate("json"));
            FileCreator(jsonfilecreate("accounts.json"), "", "");
        }

    }
}
