using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationLogFinal.Persistency
{
    public class WebAPITest<T>
    {
        #region Instance fields
        private IWebAPIAsync<T> _webAPI;

        #endregion

        #region Constructor

        public WebAPITest(IWebAPIAsync<T> webApi)
        {
            _webAPI = webApi;

        }

        public WebAPITest()
        {
        }
        #endregion

        #region Test methods for all five REST API methods
        public async Task RunAPITestLoad()
        {
            await LoadAndPrint();
        }

        public async Task RunAPITestCreate(int key ,T obj)
        {
            await RunAPITest(() => _webAPI.Create(key , obj));
        }

        public async Task RunAPITestRead(int key)
        {
            Task<T> readTask = _webAPI.Read(key);
            await readTask;
            PrintSingleRecord(readTask.Result);
        }

        public async Task RunAPITestUpdate(int key, T obj)
        {
            await RunAPITest(() => _webAPI.Update(key, obj));
        }

        public async Task RunAPITestDelete(int key)
        {
            await RunAPITest(() => _webAPI.Delete(key));
        }
        #endregion

        #region Private helper methods for test execution
        private async Task RunAPITest(Func<Task> APIMethod)
        {

            await APIMethod();

        }

        private async Task LoadAndPrint()
        {
            Task<List<T>> loadTask = _webAPI.Load();
            await loadTask;
            PrintMultipleRecords(loadTask.Result);
        }

        private void PrintMultipleRecords(List<T> records)
        {

            foreach (var record in records)
            {
                Console.WriteLine(record);
            }

        }

        private void PrintSingleRecord(T record)
        {
            {
                Console.WriteLine(record);
            }
        }


    }
}
#endregion