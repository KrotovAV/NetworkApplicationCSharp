using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ConsoleApp01S
{
    public class MyMessage
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set;}
        public string NickNameFrom { get; set; }
        public string NickNameTo { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);
        public static MyMessage? DeserializeMessageFromJson(string messageJson) => JsonSerializer.Deserialize<MyMessage>(messageJson);

        public override string ToString()
        {
            return $"От кого: { NickNameFrom}, Кому: {NickNameTo}, ДатаВремя: {DateTime}, Сообщение {Text}";
        }
        public void PrintMessageFrom()
        {
            Console.WriteLine($"Сообщение получено {DateTime} от { NickNameFrom}: {Text}");
        }
        public void PrintMessageTo()
        {
            Console.WriteLine($"Сообщение отправлено {DateTime} для {NickNameTo}: {Text}");
        }
    }
}
