using NetMQ;
using NetMQ.Sockets;

namespace ConsoleApp07HW
{
    internal class Program
    {
        static void Client(int number)
        {
            using (var client = new DealerSocket())
            {
                var r = new Random();
                Task.Delay(r.Next(100, 1000)).Wait();

                client.Connect("tcp://127.0.0.1:5556");
                client.SendFrame(number.ToString());

                Task.Delay(r.Next(100, 1000)).Wait();


                var msg = client.ReceiveFrameString();
                Console.WriteLine($"Client {number} received from Server: {msg}");
            }
        }

        static void Server()
        {
            using (var server = new RouterSocket())
            {
                int i = 0;
                server.Bind("tcp://*:5556");
                while (i < 10)
                {
                    var msg = server.ReceiveMultipartMessage();

                    Console.WriteLine("Получено сообщение " + msg.Last.ConvertToString());
                    Task.Run(() => {


                        var responseMessage = new NetMQMessage();
                        responseMessage.Append(msg.First);
                        responseMessage.Append(msg.Last.ConvertToString());
                        server.SendMultipartMessage(responseMessage);

                    });
                    i++;


                }
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                int x = i;
                Task taskCln = Task.Run(() => Client(x));
            }

            Task.Delay(1000).Wait();

            Task taskSrv = Task.Run(Server);

            Task.WaitAll(taskSrv, Task.Delay(3000));

        }
    }
}