using System.Collections.Generic;
using System.IO;
using Quiz_for_WOT.Droid.Helpers;
using Quiz_for_WOT.Interfaces;
using Xamarin.Forms;
using Environment = System.Environment;
[assembly: Dependency(typeof(FileHelper))]
namespace Quiz_for_WOT.Droid.Helpers
{
    class FileHelper : IFileHelper
    {
        public bool Exists(string filename)
        {
            string filepath = GetFilePath(filename);
            return File.Exists(filepath);
        }

        public void WriteData(string filename, string value)
        {
            string filepath = GetFilePath(filename);
           // File.WriteAllBytes(filepath,bytes);
            System.Diagnostics.Debug.WriteLine("Write is successful. path is "+filename);
            File.WriteAllText(filepath, value);
        }

        public string ReadData(string filename)
        {
            string  filepath = GetFilePath(filename);
            System.Diagnostics.Debug.WriteLine("Read from path is " + filepath);
            
            return File.ReadAllText(filepath);
           // return File.ReadAllBytes(filepath);
        }

        public IEnumerable<string> GetFiles()
        {
            return Directory.GetFiles(GetDocsPath());
        }

        public void Delete(string filename)
        {
            File.Delete(GetFilePath(filename));
        }

        // Private methods.
        string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }

        string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}