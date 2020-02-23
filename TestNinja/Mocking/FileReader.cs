using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string Read(string path);
    }

   
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public static implicit operator FileReader(global::Moq.Mock<IFileReader> v)
        {
            throw new NotImplementedException();
        }
    }
}
