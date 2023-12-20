using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ConsoleApp04S
{
    //public enum Commands
    //{
    //    Register,
    //    Delete,
    //    View,
    //    Exit
    //}
    public class MyMessage
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string NickNameFrom { get; set; }
        public string NickNameTo { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);
        public static MyMessage? DeserializeMessageFromJson(string messageJson) => JsonSerializer.Deserialize<MyMessage>(messageJson);

        public override string ToString()
        {
            return $"{DateTime}. От кого: {NickNameFrom}, Кому: {NickNameTo}, Сообщение: {Text}";
        }
        public void PrintMessageFrom()
        {
            Console.WriteLine($"{DateTime} сообщение от {NickNameFrom} для {NickNameTo}:\n" +
                $" --- {Text} ---\n" +
                $"---------------------------------------------\n");
        }
        public void PrintMessageTo()
        {
            Console.WriteLine($"{DateTime} для {NickNameTo} отправлено Сообщение:\n" +
                $" --- {Text} ---\n" +
                $"");
        }
        public async Task RegisterClient(UdpClient udpClient, IPEndPoint ipEndPoint, string From)
        {
            MyMessage myMessageRegister = new MyMessage() { Text = "Register", DateTime = DateTime.Now, NickNameFrom = From, NickNameTo = "Server" };
            await SendMessage(udpClient, ipEndPoint, myMessageRegister);
        }
        public async Task SendMessage(UdpClient udpClient, IPEndPoint ipEndPoint, MyMessage myMessageRegister)
        {
            string jsonMyMessageRegister = myMessageRegister.SerializeMessageToJson();
            byte[]? bytesRegister = Encoding.UTF8.GetBytes(jsonMyMessageRegister);
            await udpClient.SendAsync(bytesRegister, bytesRegister.Length, ipEndPoint);
            Console.WriteLine($"Похоже отправлено Сообщение");
        }
        public static MyMessage ReceptionMessage(UdpClient udpClient, ref IPEndPoint iPEndPointL)
        {
            byte[] bufferIn = udpClient.Receive(ref iPEndPointL);
            string? messageIn = Encoding.UTF8.GetString(bufferIn);
            return MyMessage.DeserializeMessageFromJson(messageIn);

        }
        public async Task ReceptionMessageAsync( UdpClient udpClient)
        {
            //var buffer = _receiveClient.Receive(ref remoteEndPoint);
            //var buffer = await _receiveClient.ReceiveAsync();

            var udpReciveresult = await udpClient.ReceiveAsync();
            byte[] bufferIn = udpReciveresult.Buffer;
            string? messageIn = Encoding.UTF8.GetString(bufferIn);
            MyMessage message = MyMessage.DeserializeMessageFromJson(messageIn);
            message.PrintMessageFrom();

        }
        public async Task Confirm(UdpClient udpClient, IPEndPoint ipEndPoint, MyMessage myMessageRegister)
        {
            
            await SendMessage(udpClient, ipEndPoint, myMessageRegister);
        }

        //public static MyMessage Listen2(UdpClient udpClient, ref IPEndPoint remoteEndPoint)
        //{

        //    MyMessage? message = null;
        //    while (true)
        //    {
        //        byte[] bufferIn = udpClient.Receive(ref remoteEndPoint);
        //        string? messageIn = Encoding.UTF8.GetString(bufferIn);
        //        message = MyMessage.DeserializeMessageFromJson(messageIn);
        //        if (bufferIn != null) break;
        //    }
        //    return message;
        //}
    }
}
