using Domain.HrModule;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.HrModule
{
    public class UserEvent
    {
        [BsonId]
        public Guid Id { get; set; }
        public EventType EventType { get; set; }
        public DateTime EventTime { get; set; }
        public User User { get; set; }
    }

    public enum EventType
    {
        Craete,
        Update,
        Delete
    }
}
