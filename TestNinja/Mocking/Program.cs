using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class Program
    {
        public static void Main()
        {
            //var service = new VideoService();
            // instead of newing up, use a dependency injection framework
            // it's responsible for newing up objects and passing them to our methods
            //var title = service.ReadVideoTitle(new FileReader());

            // To call this, now the signature needs to change
            //var title = service.ReadVideoTitle();
        }
    }
}
