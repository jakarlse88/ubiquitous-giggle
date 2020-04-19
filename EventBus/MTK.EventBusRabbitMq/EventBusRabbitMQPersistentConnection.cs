using RabbitMQ.Client;
using System;

namespace MTK.EventBusRabbitMq
{
    public interface IRabbitMQPersistentConnection : IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}