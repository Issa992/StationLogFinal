
using System.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StationLogFinal.Persistency;
using StationLogWebApplication1;

namespace UnitTest2
{
    [TestClass]
    public class WebApiMoqTest
    {
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Tasks";

        [TestMethod]
        public void CreateTest()
        {
            Mock<IWebAPIAsync<TaskModel>> mockWebApi =
                new Mock<IWebAPIAsync<TaskModel>>(ServerUrl, ApiPrefix, ApiId);

            //mockWebApi.Setup(webApi => webApi.Create(It.IsAny<TaskModel>));
        }
    }

   
}
