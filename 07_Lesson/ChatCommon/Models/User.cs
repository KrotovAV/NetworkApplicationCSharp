

namespace ChatCommon.Models
{
    public class User
    {
        public virtual List<Message>? MessagesTo { get; set; } = new List<Message>();
        public virtual List<Message>? MessagesFrom { get; set; } = new List<Message>();
        public int Id { get; set; }
        public string? FullName { get; set; }

    }
}
