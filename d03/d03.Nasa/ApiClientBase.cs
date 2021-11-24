using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    // Модификатор доступа для класса?
    public abstract class ApiClientBase
    {
        protected string apiKey;
        static readonly HttpClient client = new HttpClient();
        protected ApiClientBase()
        {
        }
        protected ApiClientBase(string apiKey)
        {
            this.apiKey = apiKey;
        }
        protected async Task<T> HttpGetAsync<T>(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(responseBody);
                return JsonSerializer.Deserialize<T>(responseBody);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                return JsonSerializer.Deserialize<T>("what need");
            }
            // Реализацию HTTP GET запроса
            // десериализацию ответа в нужный объект: HttpGetAsync<T>(string url)
            // Все это логично сделать protected, потому что понадобится только наследникам.
            // Обращаться к API мы будем с помощью HTTP GET запросов. 
            // В REST это тип идемпотентных запросов, которые отвечают за получение данных и не изменяют их (для изменения пригодились бы, например, POST, PUT или DELETE запросы). 
            // Для реализации HTTP-запросов вам понадобится HttpClient. 
            // Если запрос был выполнен успешно и имеет StatusCode = 200 (OK), получаем из JSON необходимые данные и десериализуем их. 
            // Если статус ответа иной, результат запроса необходимо вернуть тому, кто метод вызвал, и в нем вывести в консоль.
            // Так как HTTP-запросы это I/O операция, для предотвращения блокировки программы на время выполнения запроса к удаленному ресурсу (серверу API), методы классов, содержащие эти запросы, должны быть асинхронными. 
            // В этом вам помогут ключевые слова async/await. 
        }
    }
}