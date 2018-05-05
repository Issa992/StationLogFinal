using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Web.Http;
using Newtonsoft.Json;
using StationLogFinal.Model;
using StationLogFinal.ViewModel;
using HttpClient = System.Net.Http.HttpClient;



namespace StationLogFinal.Persistency
{
    public class TaskWebAPI
    {

        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net/";



        public async Task<ObservableCollection<Task1>> GetTaskAsync()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(ServerUrl+ "api/Tasks");
            var TaskList = JsonConvert.DeserializeObject<ObservableCollection<Task1>>(response);
            return TaskList;
        }


        public async Task SaveTask(Task1 task)
        {
            var url = ServerUrl + "api/Tasks";
            var taskJson = JsonConvert.SerializeObject(task);
            HttpClient client = new HttpClient();
            var httpContent = new StringContent(taskJson, Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await client.PostAsync(url, httpContent);


           

        }
        public async Task DeleteTask(int id)
        {
            using (var client = new HttpClient())
            {
                string Url = ServerUrl + "/api/" + "Tasks/" + id;
                client.BaseAddress = new Uri(Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {

                    await client.DeleteAsync(Url);

                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }


   
       
    }


}

    



