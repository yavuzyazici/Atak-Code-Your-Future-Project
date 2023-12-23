using Book;
using System.Reflection;
using System.Diagnostics;
using System.Linq;

while (true)
{
    Console.WriteLine("Welcome! Select the operation you want to perform");
    Console.WriteLine("1 - Fetch the book list");
    Console.WriteLine("2 - Add new book");
    string key = Console.ReadLine();
    IBookService bookService = new BookService();

    Thread.Sleep(1000);
    Console.Clear();

    switch (key)
    {
        case "1":
            var books = bookService.GetBooks();
            while (true)
            {
                Console.WriteLine("Welcome to the Book Listing Page.");
                Console.WriteLine("1 - Use a filter");
                Console.WriteLine("2 - List all books");

                string input = Console.ReadLine();

                Thread.Sleep(1000);
                Console.Clear();

                switch (input)
                {
                    case "1":
                        while (true)
                        {
                            Console.WriteLine("Select the type you want to list");
                            Console.WriteLine("1 - Title");
                            Console.WriteLine("2 - Author");
                            Console.WriteLine("3 - ISBN");
                            string query;

                            string RetryInput = Console.ReadLine();
                            Thread.Sleep(1000);
                            Console.Clear();
                            switch (RetryInput)
                            {
                                case "1":
                                    Console.Write("Enter the title of the book: ");
                                    query = Console.ReadLine();
                                    books.Where(x => x.Title.ToLower().Contains(query)|| x.Title.ToUpper().Contains(query)).ToList().ForEach(y => Console.WriteLine($"Book title: {y.Title} - Author: {y.Author}"));
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Write("Enter the Author of the book: ");
                                    query = Console.ReadLine();
                                    books.Where(x => x.Author.ToLower().Contains(query) || x.Author.ToUpper().Contains(query)).ToList().ForEach(y => Console.WriteLine($"Book title: {y.Title} - Author: {y.Author}"));
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Write("Enter the ISBN number of the book: ");
                                    query = Console.ReadLine();
                                    books.Where(x => x.ISBN.ToLower().Contains(query) || x.Author.ToUpper().Contains(query)).ToList().ForEach(y => Console.WriteLine($"Book title: {y.Title} - Author: {y.Author}"));
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("You dialed wrong or incorrectly");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                            }
                            //If input it correct break loop
                            if (RetryInput == "1" || RetryInput == "2" || RetryInput == "3")
                                break;
                        }
                        break;

                    case "2":
                        foreach (var book in books)
                            Console.WriteLine($"Book title: {book.Title} - Author: {book.Author}");
                        break;
                    default:
                        Console.WriteLine("You dialed wrong or incorrectly");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }

                //If input it correct break loop
                if (input == "1" || input == "2")
                    break;
            }

            break;
        case "2":
            var item = ReadLines();
            bookService.Add(item);
            Console.WriteLine("Book added successfully!");
            break;

        default:
            Console.WriteLine("You dialed wrong or incorrectly");
            Thread.Sleep(1000);
            Console.Clear();
            break;
    }
    if (key == "1" || key == "2")
        break;
    static BookItem ReadLines()
    {
        Console.WriteLine("Enter book information in order");
        Console.WriteLine("Enter book title");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the author's name");
        string author = Console.ReadLine();

        Console.WriteLine("Enter description");
        string description = Console.ReadLine();

        Console.WriteLine("Enter ISBN number");
        string isbn = Console.ReadLine();

        var item = new BookItem();
        item.Description = description;
        item.ISBN = isbn;
        item.Author = author;
        item.Title = title;

        return item;


    }
}


