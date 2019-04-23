using System.IO;

namespace Infrastructure.Extensions.Interface
{
    public interface ILicensePlateReader
    {
        string Read(Stream stream, string path);
    }
}