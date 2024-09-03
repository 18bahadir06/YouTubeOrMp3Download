using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer
{
    public class FileRepository
    {
        public void FileSave(byte[] Mp3,String FileName)
        {
            File.WriteAllBytes(FileName, Mp3);
        }
        public byte[] FileRead(String FileName) 
        { 
            return File.ReadAllBytes(FileName);
        }
    }
}
