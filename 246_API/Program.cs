namespace _246_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Регистрируем сервис BookStorage как Singleton.
            // Это означает, что в приложении будет существовать только ОДИН объект BookStorage,
            // и он будет доступен во всех контроллерах.
            builder.Services.AddSingleton<BookStorage>();

            builder.WebHost.UseUrls("http://172.16.0.13:5555");


            var app = builder.Build();

   


            app.MapControllers();

            app.Run();
        }
    }
}
