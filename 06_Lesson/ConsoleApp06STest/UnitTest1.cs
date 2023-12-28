using ConsoleApp06S;
using ConsoleApp06S.Abstracts;
using ConsoleApp06S.Services;
using System;
using System.Net;

namespace ConsoleApp06STest
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            using (var ctx = new ChatContext())
            {
                ctx.Messages.RemoveRange(ctx.Messages);
                ctx.Users.RemoveRange(ctx.Users);
                ctx.SaveChanges();
            }
        }
        //[TearDown]
        //public void TearDown()
        //{
        //    using (var ctx = new ChatContext())
        //    {
        //        ctx.Messages.RemoveRange(ctx.Messages);
        //        ctx.Users.RemoveRange(ctx.Users);
        //        ctx.SaveChanges();
        //    }
        //}

        //---------------------------------------------------------
        [Test]
        public async Task Test0()
        {
            var mock = new MockMessageSource();
            var srv = new Server(mock);
            mock.AddServer(srv);
            await srv.Start();

            using (var �tx = new ChatContext())
            {
                //Assert.IsTrue(�tx.Users.Count() == 2, "������������ �� �������");

                var user1 = �tx.Users.FirstOrDefault(x => x.FullName == "����");
                var user2 = �tx.Users.FirstOrDefault(x => x.FullName == "���");

                //Assert.IsNotNull(user1, "������������ �� �������");
                //Assert.IsNotNull(user2, "������������ �� �������");

                //Assert.IsTrue(user1.MessagesFrom.Count() == 1);
                //Assert.IsTrue(user2.MessagesFrom.Count() == 1);

                Assert.IsTrue(user1.MessagesTo.Count == 0, $"{user1.MessagesTo.Count}");
                Assert.IsTrue(user2.MessagesTo.Count == 0, $"{user2.MessagesTo.Count}");

                //var msg1 = �tx.Messages.FirstOrDefault(x => x.UserFrom == user1 && x.UserTo == user2);
                //var msg2 = �tx.Messages.FirstOrDefault(x => x.UserFrom == user2 && x.UserTo == user1);

                //Assert.AreEqual("������, �������", msg2.Text);
                //Assert.AreEqual("������, �����!!!", msg1.Text);
            }

        }
        //-------------------------------------------------------------------
        [Test]
        public async Task Register2UsersInBDTest()
        {
            var mock = new MockMessageSource();
            var srv = new Server(mock);
            mock.AddServer(srv);
            await srv.Start();

            using (var �tx = new ChatContext())
            {
                
                Assert.IsTrue(�tx.Users.Count() == 2, "������������ �� �������");
            }
        }

        [Test]
        public async Task CorrectRegisterFullNameOfUser1InBDTest()
        {
            var mock = new MockMessageSource();
            var srv = new Server(mock);
            mock.AddServer(srv);
            await srv.Start();

            using (var �tx = new ChatContext())
            {
                var user1 = �tx.Users.FirstOrDefault(x => x.FullName == "����");

                Assert.IsNotNull(user1, "������������ �� �������");
            }
        }
        [Test]
        public async Task CorrectRegisterFullNameOfUser2InBDTest()
        {
            var mock = new MockMessageSource();
            var srv = new Server(mock);
            mock.AddServer(srv);
            await srv.Start();

            using (var �tx = new ChatContext())
            {
                var user2 = �tx.Users.FirstOrDefault(x => x.FullName == "���");

                Assert.IsNotNull(user2, "������������ �� �������");
            }
        }

        [Test]
        public async Task Test1()
        {
            var mock = new MockMessageSource();
            var srv = new Server(mock);
            mock.AddServer(srv);
            await srv.Start();

            using (var �tx = new ChatContext())
            {
                //var user1 = �tx.Users.FirstOrDefault(x => x.FullName == "����");
                var user2 = �tx.Users.FirstOrDefault(x => x.FullName == "���");

                //Console.WriteLine(user1.MessagesFrom.Count());

               // Assert.IsTrue(user1.MessagesFrom.Count() != 0);
                Assert.IsTrue(user2.MessagesFrom.Count() == 0);
            }
        }


        [Test]
        public async Task CorrectTextOfMessageFromUser1ToUser2InBDTest()
        {
            var mock = new MockMessageSource();
            var srv = new Server(mock);
            mock.AddServer(srv);
            await srv.Start();

            using (var �tx = new ChatContext())
            {
                var user1 = �tx.Users.FirstOrDefault(x => x.FullName == "����");
                var user2 = �tx.Users.FirstOrDefault(x => x.FullName == "���");

                var msg1 = �tx.Messages.FirstOrDefault(x => x.UserFrom == user1 && x.UserTo == user2);
                var msg2 = �tx.Messages.FirstOrDefault(x => x.UserFrom == user2 && x.UserTo == user1);

                Assert.AreEqual("������, �����!!!", msg1.Text);
            }
        }

        [Test]
        public async Task CorrectTextOfMessageFromUser2ToUser1InBDTest()
        {
            var mock = new MockMessageSource();
            var srv = new Server(mock);
            mock.AddServer(srv);
            await srv.Start();

            using (var �tx = new ChatContext())
            {
                var user1 = �tx.Users.FirstOrDefault(x => x.FullName == "����");
                var user2 = �tx.Users.FirstOrDefault(x => x.FullName == "���");

                var msg1 = �tx.Messages.FirstOrDefault(x => x.UserFrom == user1 && x.UserTo == user2);
                var msg2 = �tx.Messages.FirstOrDefault(x => x.UserFrom == user2 && x.UserTo == user1);

                Assert.AreEqual("������, �������", msg2.Text);
            }
        }
        //[Test]
        //public async Task ClientListener_ReceivesMessage_CallsConfirm()
        //{
        //    var name = "TestClient";
        //    var address = "127.0.0.1";
        //    var port = 1234;

        //    var messageSourceMock = new Mock<IMessageSource>();
        //    var udpClientMock = new Mock<UdpClient>();

        //    var client = new Client(name, address, port)
        //    {
        //        _messageSouce = messageSourceMock.Object,
        //        udpClientClient = udpClientMock.Object
        //    };

        //    var remoteEndPoint = new IPEndPoint(IPAddress.Any, 5678);
        //    var netMessage = new NetMessage { NickNameFrom = "Sender", Text = "Hello", Command = Command.Message };

        //    messageSourceMock.Setup(m => m.Receive(ref remoteEndPoint)).Returns(netMessage);
        //    messageSourceMock.Setup(m => m.SendAsync(It.IsAny<NetMessage>(), It.IsAny<IPEndPoint>())).Returns(Task.CompletedTask);

        //    await client.ClientListener();

        //    messageSourceMock.Verify(m => m.Receive(ref remoteEndPoint), Times.Once);
        //    messageSourceMock.Verify(m => m.SendAsync(It.IsAny<NetMessage>(), remoteEndPoint), Times.Once);
        //}

        //[Test]
        //public void Register_CallsMessageSourceSendAsync()
        //{

        //    var name = "TestClient";
        //    var address = "127.0.0.1";
        //    var port = 1234;

        //    var messageSourceMock = new Mock<IMessageSource>();
        //    var udpClientMock = new Mock<UdpClient>();

        //    var client = new Client(name, address, port)
        //    {
        //        _messageSouce = messageSourceMock.Object,
        //        udpClientClient = udpClientMock.Object
        //    };

        //    var remoteEndPoint = new IPEndPoint(IPAddress.Any, 5678);


        //    client.Register(remoteEndPoint);

        //    messageSourceMock.Verify(m => m.SendAsync(It.IsAny<NetMessage>(), remoteEndPoint), Times.Once);
        //}


        //[TestMethod]
        //public void TestMessageMethod()
        //{
        //    var messageSource = new Mock<IMessageSource>();
        //    var server = new Server(messageSource.Object);
        //    server.Clients.Add("User1", new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
        //    var testMessage = new NetMessage { NickNameFrom = "User2", NickNameTo = "User1", Text = "Test Message" };
        //    server.RelyMessage(testMessage).Wait();
        //    messageSource.Verify(mock => mock.SendAsync(testMessage, It.IsAny<IPEndPoint>()), Times.Once);
        //}
    }
}
