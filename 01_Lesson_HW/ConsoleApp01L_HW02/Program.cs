using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp01L_HW02
{
    internal class Program
    {
        public static void MyServer()
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Сервер ждет сообщение от клиента");
            while (true)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                if (buffer == null) break;
                var messageText = Encoding.UTF8.GetString(buffer);

                MyMessage? message = MyMessage.DeserializeMessageFromJson(messageText);
                message?.PrintMessageFrom();
                //--------------------------------------------
                if (message != null)
                {
                    byte[] bufferOut = Encoding.UTF8.GetBytes($"*** Сообщение - {message.Text} - получено сервером {message.DateTime}.\n ");
                    
                    udpClient.Send(bufferOut, bufferOut.Length, iPEndPoint);
                }
                //---------------------------------------------
            }
        }

        static void Main(string[] args)
        {
            
            /*
             * Разработать класс простое в чат-приложение способном передавать 
             * с компьютера на компьютер сообщения, состоящее из даты, никнейма 
             * отправителя и текста сообщения. 
             */


            /*
             * Добавить JSON сериализацию и десериализацию в класс. 
             * И протестировать путем компоновки простого сообщения, сериализации и десериализации этого сообщения.
             */

            MyMessage textMessage = new MyMessage() { Text = "hello", DateTime = DateTime.Now, NickNameFrom = "Artem", NickNameTo = "All" };
            
            string jsonMessage = textMessage.SerializeMessageToJson();
            //Console.WriteLine(jsonMessage);

            MyMessage? texDeserilized = MyMessage.DeserializeMessageFromJson(jsonMessage);

            /*
             * Написать утилиту, которая умеет работать как сервер или же как клиент
             * в зависимости от параметров командной строки. 
             * Клиент отправляет сообщения на сервер, сервер принимает.
             * Сервер умеет отправлять сообщения клиенту, а клиент принимать.
             */
            Console.WriteLine("--------------");
            MyServer();


        }
    }
}