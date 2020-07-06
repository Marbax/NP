using System;

namespace Messaging
{
    [Serializable]
    public class Message : IMessage
    {
        public string SourceEP { get; set; }
        public string DestinationEP { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public string WhiteSourceEP { get; set; }
        public string SenderName { get; set; }
        public string SenderCId { get; set; }
        public string DestinationName { get; set; }

        public override string ToString() => $"Sender = {SenderName?.ToString()}{SenderCId?.ToString()} , Source EP = {SourceEP?.ToString()} , " +
            $"White Source EP = {WhiteSourceEP?.ToString()} , Destination EP = {DestinationEP?.ToString()} , " +
            $"Destination = {DestinationName?.ToString()} , Text = {Text?.ToString()} , Send Time = {SendTime.ToString()}";
    }
}
