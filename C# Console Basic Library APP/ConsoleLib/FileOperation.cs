namespace Book
{
    public class FileOperation
    {
        public static string ReadFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\books.json";
            string output = File.ReadAllText(path);
            return output;
        }

        public static void SaveFile(string data)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\books.json";
            File.WriteAllText(path, data);
        }
    }
}
