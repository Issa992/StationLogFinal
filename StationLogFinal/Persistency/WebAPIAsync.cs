using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StationLogFinal.Model;
using Task = System.Threading.Tasks.Task;

namespace StationLogFinal.Persistency
{
    public class WebAPIAsync<T> : IWebAPIAsync<T> where T : class
    {

        #region Instance fields
        private string _serverURL;
        private string _apiPrefix;
        private string _apiID;
        private HttpClientHandler _httpClientHandler;
        private HttpClient _httpClient;
        private IWebAPIAsync<T> _webApiAsyncImplementation;

        public WebAPIAsync()
        {
        }

        #endregion

        #region Constructor
        public WebAPIAsync(string serverURL, string apiPrefix, string apiID)
        {
            _serverURL = serverURL;
            _apiID = apiID;
            _apiPrefix = apiPrefix;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.UseDefaultCredentials = true;
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.BaseAddress = new Uri(_serverURL);
        }


        public async Task Create(T obj)
        {
            var url = _serverURL + "/" + _apiPrefix + "/" + _apiID;
            var taskJson = JsonConvert.SerializeObject(obj);

            HttpClient client = new HttpClient();


            var httpContent = new StringContent(taskJson, Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await client.PostAsync(url, httpContent);


        }


        #endregion



        public async Task Delete(int key)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            await client.DeleteAsync(url);
        }
        //working with loading////////////////////////////////////////////////////////////
        //public async TaskModel<ObservableCollection<Task1>> Load()
        //{
        //    HttpClient client = new HttpClient();
        //    string url = _serverURL + "/" + _apiPrefix + "/" + _apiID;
        //    string response = await client.GetStringAsync(url);

        //    var tasks = JsonConvert.DeserializeObject<ObservableCollection<Task1>>(response);
        //    return tasks;
        //}

        public async Task<List<T>> Load()
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID;

            var jsonResponse = await client.GetStringAsync(url);
            var TaskResult = JsonConvert.DeserializeObject<List<T>>(jsonResponse);
            return TaskResult;
        }



        public async Task<T> Read(int key)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            var jsonResponse = await client.GetStringAsync(url);
            var Task = JsonConvert.DeserializeObject<T>(jsonResponse);
            return Task;
        }

        public async Task Update(int key, T obj)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            string jsonResponse = JsonConvert.SerializeObject(obj);
            await client.PutAsync(url, new StringContent(jsonResponse, Encoding.UTF8, "application/json"));
        }
    }
}