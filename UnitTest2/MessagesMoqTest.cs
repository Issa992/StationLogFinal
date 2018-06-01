using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StationLogFinal.Handlers;
using StationLogWebApplication1.Models;
using StationLogWebApplication1;
using System;
using StationLogFinal.ViewModel;

namespace UnitTest2
{
    [TestClass]
    class MessagesMoqTest
    {
        Mock<MessageHandler> mockHandler = new Mock<MessageHandler>();
        Mock<MessageViewModel> mockVM = new Mock<MessageViewModel>();
        
        
        public void SetUpProperties()
        {


            mockVM.SetupProperty(m => m.newMessage, new Message
            { CreationTime = DateTime.Now,
                IsRead = false,
                MessageId = 1,
                Messages = "test",
                ReceiverId = 1,
                SenderId = 2,
            });
            //mockHandler.SetupProperty(m => m.ViewModel, mockVM);
        }

        [TestMethod]
        public void SendMessageTest()
        {
            SetUpProperties();
            mockHandler.Setup(mock => mock.SendMessage());
            //mockHandler.Setup(mock => mock.SendMessage());
            
        }

    }
}
