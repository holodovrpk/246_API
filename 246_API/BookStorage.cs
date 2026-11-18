using System.Text.Json;

namespace _246_API
{
    public class BookStorage
    {
        private const string FilePath = "data.json";

        public List<Book> Load()
        {
            if (!File.Exists(FilePath))
                return new List<Book>();

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Book>>(json);
        }

        public void Save(List<Book> books)
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }


    }
}
