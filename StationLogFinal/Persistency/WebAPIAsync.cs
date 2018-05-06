﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StationLogFinal.Model;
using Task = System.Threading.Tasks.Task;

namespace myGenericDBEFandWSMovies
{
    public class WebAPIAsync<T>
    {
        #region Instance fields
        private string _serverURL;
        private string _apiPrefix;
        private string _apiID;
        private HttpClientHandler _httpClientHandler;
        private HttpClient _httpClient;
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
        #endregion

        #region Methods
        public async Task Delete(int key)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            CancellationToken cancellationToken = new CancellationToken();
            HttpResponseMessage response = await client.DeleteAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        //public async Task<ObservableCollection<<T>> Load()
        //{
        //    HttpClient client = new HttpClient();
        //    string url = _serverURL + "/" + _apiPrefix + "/" + _apiID;
        //    string response = client.GetStringAsync(url);

        //    ObservableCollection<T> tasks = JsonConvert.DeserializeObject<ObservableCollection<T>>(response);
        //    return tasks;
        //}

        public async Task<T> Read(int key)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            string response = await client.GetStringAsync(url);
            var tasks = JsonConvert.DeserializeObject<T>(response);
            return tasks;
        }

        public async Task Update(int key, T obj)
        {
            HttpClient client = new HttpClient();
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            string postBody = JsonConvert.SerializeObject(obj);
            HttpResponseMessage response = await client.PutAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task Create(int key, T obj)
        {
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            string postBody = JsonConvert.SerializeObject(obj);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

        }
        #endregion
    }
}
