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
            //Created array for file content
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return fileContent;
        }
    }
}
