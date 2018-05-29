using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StationLogFinal.Persistency;
using StationLogWebApplication1;


namespace UnitTest
{ 
    [TestClass]
    class MoqWebApiTest
    {
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Tasks";
        Mock<IWebAPIAsync<TaskModel>> WebApiMocked;
        Mock<TaskModel> TaskMocked;


        [TestMethod]
        public void TestMethod11()
        {
            //TaskMocked = new Mock<TaskModel>();
            //TaskMocked.SetupProperty(task => task.DateTime, DateTime.Now);
            //TaskMocked.SetupProperty(task => task.Description, "some task");
            //TaskMocked.SetupProperty(task => task.StationId, 1);
            //TaskMocked.SetupProperty(task => task.TaskId, 87);
            //TaskMocked.SetupProperty(task => task.IsDone, false);
            //TaskMocked.SetupProperty(task => task.UserId, 1);
            //TaskMocked.SetupProperty(task => task.IsRepeatable, true);
            WebApiMocked = new
              Mock<StationLogFinal.Persistency.IWebAPIAsync<TaskModel>>(ServerUrl, ApiPrefix, ApiId);
            WebApiMocked.Setup(api => api.Create(It.IsAny<TaskModel>()).IsCompletedSuccessfully);

        }
    }
}