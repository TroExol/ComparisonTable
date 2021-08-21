using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparisonTable.Classes
{
    public class HttpRequest
    {
        static readonly HttpClient client = new HttpClient();
        
        /// <summary>
        /// GET запрос
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <returns>Ответ сервера</returns>
        public static string Get(string url)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.8 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse) request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader =
                new StreamReader(stream ?? throw new InvalidOperationException("Не удалось получить данные")))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Асинхронный GET запрос
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <returns>Ответ сервера</returns>
        public static async Task<string> GetAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.8 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse) await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader =
                new StreamReader(stream ?? throw new InvalidOperationException("Не удалось получить данные")))
            {
                return await reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// POST Запрос
        /// </summary>
        /// <param name="url">Адрес сервера</param>
        /// <param name="data">Отправляемые данные</param>
        /// <param name="contentType">Тип отправляемых данных</param>
        /// <param name="method">Метод запроса</param>
        /// <returns>Ответ сервера</returns>
        public static string Post(string url, string data, string contentType, string method = "POST")
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);

            var request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.8 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;

            using (var requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            using (var response = (HttpWebResponse) request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader =
                new StreamReader(stream ?? throw new InvalidOperationException("Не удалось отправить данные")))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Асинхронный POST Запрос
        /// </summary>
        /// <param name="url">Адрес сервера</param>
        /// <param name="data">Отправляемые данные</param>
        /// <param name="contentType">Тип отправляемых данных</param>
        /// <param name="method">Метод запроса</param>
        /// <returns>Ответ сервера</returns>
        public static async Task<string> PostAsync(string url, string data, string contentType, string method = "POST")
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.8 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;

            using (Stream requestBody = request.GetRequestStream())
            {
                await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader =
                new StreamReader(stream ?? throw new InvalidOperationException("Не удалось отправить данные")))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}