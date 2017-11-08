using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMA3_SearchTool_3009422
{
    class FileCollection
    {
        private string folderPath;  // folder path where this collection of files is found
        private int counter;  // could be changed to long
        private Dictionary<string, int> paths;
        private List<string> ids;

        // constructor
        public FileCollection(string folderPath)
        {
            this.folderPath = folderPath;
            counter = 0;
            paths = new Dictionary<string, int>();
            ids = new List<string>();
        }

        // constructor with string array
        public FileCollection(string folderPath, string[] files)
        {
            this.folderPath = folderPath;
            counter = 0;
            paths = new Dictionary<string, int>();
            ids = new List<string>();

            for (int i = 0; i < files.Length; i++)
            {
                this.Add(files[i]);
            }
        }

        // indexer
        public string this[int id]
        {
            get { return this.FilePath(id); }
        }

        // return the ID for this file
        public int FileId(string path)
        {
            return paths[path];
        }

        // return the path for this id
        public string FilePath(int id)
        {
            return ids[id];
        }

        // assign id to this new file
        public int Add(string path)
        {
            if (paths.ContainsKey(path)) // return existing id for given path
            {
                return this.FileId(path);
            }
            else // assign current counter value as id, then increment counter
            {
                int id = counter;
                paths[path] = id;
                ids.Add(path);
                counter++;
                return id;
            }
        }

        // FolderPath property
        public string FolderPath
        {
            get { return folderPath; }
        }

        // Length property
        public int Length
        {
            get { return counter; }
        }
    }
}
