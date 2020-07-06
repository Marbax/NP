using System;

namespace Messaging
{
    public interface IMessage
    {
        string SenderName { get; set; }
        string SenderCId { get; set; }
        string SourceEP { get; set; }
        string WhiteSourceEP { get; set; }
        string DestinationEP { get; set; }
        string DestinationName { get; set; }
        string Text { get; set; }
        DateTime SendTime { get; set; }
    }
}
