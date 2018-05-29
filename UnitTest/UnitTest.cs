
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using Moq;
using StationLogWebApplication1;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IWebAPIAsync<TaskModel>>();
            WebAPIAsync<TaskModel> TwebApiAsync = new WebAPIAsync<TaskModel>();
            WebAPITest<TaskModel> TaskWebApiTest = new WebAPITest<TaskModel>(TwebApiAsync);
            TaskModel task = new TaskModel(1, DateTime.Today, "wwwwww", true, true, DateTime.Now, 1, 1);
            //await TaskWebApiTest.RunAPITestCreate(task,mock.Object);
            mock.Setup(x => x.Create(It.IsAny<TaskModel>()));
            Assert.AreEqual(1, task.UserId);

    
            
        }
    }
}
