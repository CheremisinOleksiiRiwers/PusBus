using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PubSub.Consumer.Infrastructure.Interfaces
{
    public interface IMessageConsumer
    {
        string? ReadMessage(CancellationToken cancellationToken);
    }
}
