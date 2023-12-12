namespace monoos.src
{
    internal class Util
    {
        public static string GetFileName(string filePath)
        {
            int startIndex = filePath.LastIndexOf(@"\") + 1;
            int endIndex = filePath.IndexOf(".", startIndex);
            return filePath.Substring(startIndex, endIndex - startIndex);
        }
    }
}