using System;
using System.Net.Http;
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
        protected async void HttpGetAsync<T>(string url)
        {
            try	
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
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