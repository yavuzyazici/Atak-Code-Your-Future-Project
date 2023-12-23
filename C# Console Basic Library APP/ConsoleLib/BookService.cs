using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class BookService : IBookService
    {
        public void Add(BookItem item)
        {
            string output = FileOperation.ReadFile();
            var books = JsonConvert.DeserializeObject<List<BookItem>>(output);

            // Checking if there is a book with the same ISBN number in the list
            if (books.Any(x=> x.ISBN == item.ISBN))
            {
                Console.WriteLine("The same book already exists. Check the ISBN number");
                return;
            }


            // We included it in the list
            books.Add(item);

            var jsonString = JsonConvert.SerializeObject(books);
            File.WriteAllText("books.json", jsonString, Encoding.UTF8);
        }

        public List<BookItem> GetBooks()
        {
            string output = FileOperation.ReadFile();
            var books = JsonConvert.DeserializeObject<List<BookItem>>(output);
            return books;
        }

        // Assignment 3: List the books according to the author name that we will give as a parameter
    }
}
