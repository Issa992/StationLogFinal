
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
        const string ApiId = "Logs";

        [TestMethod]
        public void CreateTest()
        {
            Mock<IWebAPIAsync<Log>> mockWebApi =
                new Mock<IWebAPIAsync<Log>>(ServerUrl, ApiPrefix, ApiId);

            mockWebApi.Setup(mock => mock.GetType());
        }
    }

   
}
