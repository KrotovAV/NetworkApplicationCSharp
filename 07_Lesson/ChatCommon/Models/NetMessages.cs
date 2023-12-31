using System.Net;
using System.Text.Json;


namespace ChatCommon.Models
{
    public class NetMessage
    {

        public int? Id;
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string? NickNameFrom { get; set; }
        public string? NickNameTo { get; set; }
        public IPEndPoint? EndPoint { get; set; }
        public Command Command { get; set; }

        public string SerializeMessageToJSON() => JsonSerializer.Serialize(this);

        public static NetMessage? DeserializeMessageFromJSON(string message) => JsonSerializer.Deserialize<NetMessage>(message);

        public void PrintGetMessageFrom()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{DateTime} от {NickNameFrom}\nПолучено сообщение * {Text} * ";
        }

    }
}
