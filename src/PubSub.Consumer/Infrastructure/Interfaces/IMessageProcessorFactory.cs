using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Consumer.Infrastructure.Abstraction;

namespace PubSub.Consumer.Infrastructure.Interfaces
{

    public interface IMessageProcessorFactory {

        BaseMessageProcessor GetProcessorsChain();
    
    }
}
