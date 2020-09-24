using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            //Created array for file content.
            string[] fileContent;
            //Try-catch method to read the file and throw an exception if failed.
            try
            {
                fileContent = File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //The Read method should return the content of the file.
            return fileContent;
        }
    }
}
