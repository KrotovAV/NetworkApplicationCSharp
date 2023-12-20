using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp04S
{
    public class Client
    {
        //public static IPEndPoint iPEndPointListen;
        MyMessage myMessage = new MyMessage();
        public async Task ClientListener(UdpClient udpClient)
        {
            IPEndPoint iPEndPointListen = null;
            while (true)
            {
                try
                {
                    Console.WriteLine("ClientListener Жду сообщения ");
                    MyMessage? message = MyMessage.ReceptionMessage(udpClient, ref iPEndPointListen);
                    message.PrintMessageFrom();

                    //await myMessage.Confirm(udpClient, iPEndPointListen, message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при получении сообщения: " + ex.Message);
                }
            }
        }
        public async Task ClientListener2(UdpClient udpClient)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("ClientListener2 Жду сообщения ");

                    await myMessage.ReceptionMessageAsync(udpClient);
                    



                    //var udpReciveresult = await udpClient.ReceiveAsync();
                    //byte[] bufferIn = udpReciveresult.Buffer;
                    //string? messageIn = Encoding.UTF8.GetString(bufferIn);
                    //MyMessage message = MyMessage.DeserializeMessageFromJson(messageIn);
                    //message.PrintMessageFrom();


                    //await myMessage.Confirm(udpClient, iPEndPointListen, message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при получении сообщения: " + ex.Message);
                }
            }
        }
        public async Task ClientSender(string From, string ip, UdpClient udpClient, IPEndPoint ipEndPoint)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("ClientSender Готов к отправке запущен");

                    IBuilderMyMessage builderMyMessage = new ConcreteBuilder();
                    builderMyMessage.BuildNickNameFrom(From);
                    builderMyMessage.BuildNickNameTo();
                    builderMyMessage.BuildText();
                    MyMessage myMessage = builderMyMessage.Build();

                    await myMessage.SendMessage(udpClient, ipEndPoint, myMessage);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при обработке сообщения: " + ex.Message);
                }
            }
        }

        public async Task ClientWork(string From, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            //await myMessage.RegisterClient(udpClient, ipEndPoint, From);

            //await ClientSender(From, ip, udpClient, ipEndPoint);
            //await ClientListener(udpClient);
       
            await ClientListener2(udpClient);
            
        }
    }
}
