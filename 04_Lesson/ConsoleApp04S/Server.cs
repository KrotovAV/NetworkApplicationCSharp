using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04S
{
    public class Server
    {
        static public Dictionary<string, IPEndPoint> Users { get; set; } = new Dictionary<string, IPEndPoint>()
        {
            {"Server", new IPEndPoint(IPAddress.Any, 0) }
        };

        public void RegisterOnServer(string user, IPEndPoint iPEndPoint) 
        {
            if (user != null)
            {
                //Console.WriteLine($"{iPEndPoint} iPEndPoint Клиента");
                Users.Add(user, iPEndPoint);
            }

        }

        public void Delete(string user) 
        { 
            if(Users.Keys.Contains(user))
            {
                Users.Remove(user);
            }
        }
        public void PrintUsers()
        {
            foreach (var i in Users)
            {
                Console.WriteLine(i.Key + ":" + i.Value);
            }
        }
        public string ViewUsers()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Список пользователей в сети\n-------------------------\n");
            foreach (var i in Users)
            {
                sb.AppendLine(i.Key + " : " + i.Value);
            }
            sb.Append("-------------------------\n");
            return sb.ToString();
        }
        public static void MyServer(CancellationToken token)
        {
            MyMessage myMessage = new MyMessage();
            Server s = new Server();
            Console.WriteLine($"{DateTime.Now} Сервер включен и готов к принятию и отправке сообщений\n"+ 
                    $"---------------------------------------------\n");
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            //IPEndPoint iPEndPointListen = new IPEndPoint(IPAddress.Any, 0);
            //Console.WriteLine(iPEndPoint.Port.ToString());

            string ip = "127.0.0.1";
            IPEndPoint testEndPoint = new IPEndPoint(IPAddress.Parse(ip), 56881); //127.0.0.1:56881;
            //IPEndPoint testEndPoint = new IPEndPoint(IPAddress.Parse"127.0.0.1", 12345);
            for (int i = 0; i < 5; i++)
            {
                MyMessage myMes = new MyMessage() { Text = $" {i}", DateTime = DateTime.Now, NickNameFrom = "Server", NickNameTo = "123" };
                myMessage.SendMessage(udpClient, testEndPoint, myMes);
                Thread.Sleep(2000);
            }


            Task.Run(async () =>
            {

                while (!token.IsCancellationRequested)
                {
                    IPEndPoint remoteEndPoint = null;
                    MyMessage? message = MyMessage.ReceptionMessage(udpClient, ref remoteEndPoint);
                    message?.PrintMessageFrom();

                    //Console.WriteLine(remoteEndPoint);
                    //Console.WriteLine(remoteEndPoint.Port.ToString());

                    if (!Users.ContainsKey(message.NickNameFrom))
                    {
                        s.RegisterOnServer(message.NickNameFrom, remoteEndPoint);
                        Console.WriteLine(s.ViewUsers());
                        //MyMessage myMessageRegister = new MyMessage() { Text = "Зарегистрирован в сети", DateTime = DateTime.Now, NickNameFrom = "Server", NickNameTo = message.NickNameFrom };
                        //myMessage.SendMessage(udpClient, remoteEndPoint, message);
                    }
                    

                    IPEndPoint iPEndPointTo = Users[message.NickNameTo];
                    Console.WriteLine("xxx " + iPEndPointTo);
                    myMessage.SendMessage(udpClient, iPEndPointTo, message);


                    //if (message.NickNameTo.Contains("Server") || message.NickNameTo.Contains("server"))
                    //{

                    //}

                    //IPEndPoint iPEndPointTo = Users[message.NickNameTo];
                    //MyMessage.SendMessage(udpClient, iPEndPointTo, message);

                    //------------------

                    //if (Users.ContainsKey(message.NickNameTo))
                    //{
                    //IPEndPoint iPEndPointTo = Users[message.NickNameTo];

                    //Console.WriteLine($"Клиент {message.NickNameTo} найден"); 
                    //Console.WriteLine($"Порт клиента {iPEndPointTo.Port.ToString()}");
                    //byte[] bufferSendMessage = buffer;

                    //Console.WriteLine($"Сообщение: {Encoding.UTF8.GetString(bufferSendMessage)}");


                    ////полученное сообщение пересылаем поновому адресу
                    //udpClient.Send(bufferSendMessage, bufferSendMessage.Length, iPEndPointTo);

                    ////Console.WriteLine($"Сообщение перепавлено клиенту {message.NickNameTo}");
                    //}
                    //---------------


                    //Console.WriteLine("Server".Contains(message.NickNameTo));
                    //Console.WriteLine("Server".Equals(message.NickNameTo));

                    //if (message != null)
                    //{
                    //    string generateMess = $"* * * Служебное сообщение от Сервера: сообщение {message.Text}" +
                    //        $" для отправки {message.NickNameTo} " +
                    //        $"получено сервером {message.DateTime}.\n";
                    //Console.WriteLine($"Клиент {message.NickNameTo} XXXXXX");
                    //if (!"Server".Contains(message.NickNameTo) || !"server".Contains(message.NickNameTo))
                    //{
                    // из полученного сообщения берём получателя и выясням его эндпойнт
                    //if (Users.ContainsKey(message.NickNameTo))
                    //{
                    //IPEndPoint iPEndPointTo = Users[message.NickNameTo];

                    //    Console.WriteLine($"Клиент {message.NickNameTo} найден"); 
                    //    //полученное сообщение пересылаем поновому адресу
                    //-------------------------------------
                    //udpClient.Send(buffer, buffer.Length, iPEndPointTo);
                    //Console.WriteLine($"Сообщение перепавлено клиенту {message.NickNameTo}");
                    //---------------------------------
                    //}
                    //else
                    //{
                    //generateMess = generateMess + $" {message.NickNameTo} - не найден,\n" +
                    //$"Возможно получатель не в сети\n" +
                    //$"Отправтье Server сообщение View что бы проверить, кто сейчс в сети\n" +
                    //$"Или проверьте правильность написания получателя";
                    //}

                    //}
                    //else
                    //{
                    //if (message.Text.Contains("View") || message.Text.Contains("view"))
                    //{
                    //    Console.WriteLine($"Клиент {message.NickNameFrom} запросил список пользователей в сети.");
                    //    generateMess = generateMess + s.ViewUsers();
                    //    Console.WriteLine("xxx");
                    //    Console.WriteLine(generateMess);
                    //    Console.WriteLine("xxx");
                    //}
                    //}
                    //сгенерированное сообщение от севера отправителю
                    //byte[] bufferOut = Encoding.UTF8.GetBytes(generateMess);
                    //udpClient.Send(bufferOut, bufferOut.Length, iPEndPoint);


                    //---------------
                    //byte[] bufferSendMessage = buffer;
                    //IPEndPoint iPEndPointTo = Users[message.NickNameTo];
                    //udpClient.Send(bufferSendMessage, bufferSendMessage.Length, iPEndPointTo);
                    //-----------------

                    //если exit, то уведомления в окне севера и выключение сервера
                    if (message.Text.Contains("Exit") || message.Text.Contains("exit"))
                    {
                        Console.WriteLine($"Клиент {message.NickNameFrom} будет выключен.");
                        Console.WriteLine("Сервер выключен.");
                        Console.WriteLine();
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine("Для выключения приложения нажмите любую клавишу.");
                    }
                }
                //}
            }, token);
        }


    }
}
