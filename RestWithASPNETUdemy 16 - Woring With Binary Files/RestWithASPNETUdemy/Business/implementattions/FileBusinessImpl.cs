using RestWithASPNETUdemy.Data.VO;
using System.IO;

namespace RestWithASPNETUdemy.Business.implementattions
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fulPath = path + "\\Other\\Untitled Diagram.pdf";
            return File.ReadAllBytes(fulPath);
        }
    }
}
