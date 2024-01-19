using Praktik.API.Services;

public class BookService
{
    private readonly DataService _dataService;

    public BookService(DataService dataService)
    {
        _dataService = dataService;
    }

    public List<Book> GetBooks()
    {
        var books = _dataService.Books.ToList();
        return books;
    }

    public Book GetBookById(int id)
    {
        return _dataService.Books.FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(Book book)
    {
        try
        {
            book.Id = _dataService.Books.Count + 1;
            _dataService.Books.Add(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in AddBook: {ex.Message}");
            throw;
        }
    }

    public void UpdateBook(int id, Book updatedBook)
    {
        var existingBook = _dataService.Books.FirstOrDefault(b => b.Id == id);

        if (existingBook != null)
        {
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.PublishedYear = updatedBook.PublishedYear;
        }
    }

    public void DeleteBook(int id)
    {
        var bookToDelete = _dataService.Books.FirstOrDefault(b => b.Id == id);

        if (bookToDelete != null)
        {
            _dataService.Books.Remove(bookToDelete);
        }
    }
}
