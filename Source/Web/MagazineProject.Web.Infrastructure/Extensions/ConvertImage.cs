namespace MagazineProject.Web.Infrastructure.Extensions
{
    using System.IO;
    using System.Reflection;

    using MagazineProject.Common;

    public static class ConvertImage
    {
        public static byte[] ToBytes(string filePath)
        {
            var directory = AssemblyHelpers.GetDirectoryForAssembyl(Assembly.GetExecutingAssembly());
            var file = File.ReadAllBytes(directory + filePath);

            return file;
        }
    }
}