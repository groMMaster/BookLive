using System.IO;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;

namespace BookLive.Application.Utils;
public static class ImageExtensions
{
    public static byte[] GetByteArray(string path) => System.IO.File.ReadAllBytes(path);

}