using CCA_BE.Models;

namespace CCA_BE.Docs
{
    //class responsible of getting folders associated to the user logged in
    public class FolderSystem
    {
        //gets folders
        public static List<Folder> getFolders(string nameid) {

            //path to the folder
            string sourcepath = "..\\..\\Files\\" + nameid;
            //gets all folders inside the folder of the user
            string[] dirs = Directory.GetDirectories(sourcepath);

            List<Folder> folders = new List<Folder>();
            
            //for each folder found it gets all the files in it
            foreach( string dir in dirs)
            {
                string folderName = Path.GetFileName(dir);
                Folder folder = new Folder { Name = folderName };
                //gets files
                getFiles(Path.Combine(sourcepath,folderName),folder);
                //adds to the atribute in the object
                folders.Add(folder);
            }
            return folders;
            
        }

        //gets files
        private static void getFiles(string sourcePath,Folder folder)
        {
            //gets path to files
            var files = Directory.GetFiles(sourcePath);

            foreach (string file in files)
            {
                //gets the name of the files
                string fileName = Path.GetFileName(file);
                //adds to the atribute in the object
                folder.FileNames.Add(fileName);
            }
        }

        //prints list of folders and files in it (object Folder)
        private static void PrintFolders(List<Folder> folders) 
        {
            foreach(Folder folder in folders)
            {
                Console.WriteLine("Folder:" + folder.Name);
                foreach(string file in folder.FileNames){
                    Console.WriteLine("\t File:"+ file);
                }
            }
        }

    }

}
