using System;
using System.IO;

namespace ProjectB_Group2
{
    public class Filemanager
    {
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

        public static void FileCreator(string x)
        {
            if (!File.Exists(x))
            {
                File.Create(x);
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
            FileCreator(jsonfilecreate("accounts.json"));
        }

    }
}
