using System;
using Newtonsoft.Json;

namespace MTK.EventBus.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
        }

        [JsonProperty]
        public Guid Id { get; set; }

        [JsonProperty]
        public DateTime CreationDate { get; set; }
    }
}