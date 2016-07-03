using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            Queue<string> subfolders = new Queue<string>();
            subfolders.Enqueue(path);
            while (subfolders.Count != 0)
            {
                //TODO dequeue the folder at the start of the queue
                string currentPath = subfolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                //TODO print the folder path
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");
                foreach (string directoryPath in Directory.GetDirectories(path))
                {
                    //TODO add all its subfolders at the end of the queue
                    subfolders.Enqueue(directoryPath);
                }
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));
            }
        }
    }
}
