namespace Book
{
    public interface IBookService
    {
        List<BookItem> GetBooks();
        void Add(BookItem item);
    }
}
