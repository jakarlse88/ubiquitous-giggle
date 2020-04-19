using System.Threading.Tasks;
using MTK.EventBus.Events;

namespace MTK.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> :
        IIntegrationEventHandler where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}