using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _246_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Ссылка на сервис-хранилище книг.
        // BookStorage — Singleton-сервис, который мы регистрировали в Program.cs.
        BookStorage storage;


        // Через конструктор получаем BookStorage из DI-контейнера.
        // ASP.NET Core автоматически передаст готовый объект BookStorage.
        public BooksController(BookStorage _storage)
        {
            storage = _storage;
        }

        // Сюда будут добавлены обработчики маршрутов
        // ...
        [HttpGet] // обработка GET-запроса: /api/books
        public IActionResult GetAll()
        {
            List<Book> books = storage.Load(); // загружаем список книг из хранилища
            return Ok(books);           // возвращаем 200 OK + данные
        }

        [HttpGet("{id}")]        // обработка GET-запроса: /api/books/5
        public IActionResult GetById(int id)
        {
            List<Book> books = storage.Load();                     // загружаем все книги
            Book book = books.FirstOrDefault(b => b.Id == id); // ищем книгу по Id

            if (book == null)
                return NotFound();                          // если не нашли → 404

            return Ok(book);                                // возвращаем найденную книгу
        }







    }
}
