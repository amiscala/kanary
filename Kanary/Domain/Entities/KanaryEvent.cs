using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Kanary.Domain.Entities.CustomResourceDefinitions;

namespace Kanary.Domain.Entities
{
    public class KanaryEvent
    {

        public int Iteration { get; set; }
        public WatchEventType EventType { get; set; }
        public KanaryCustomResource KanaryCustomResource { get; set; }

        public KanaryEvent(WatchEventType eventType, KanaryCustomResource kanaryCustomResource, int iteration)
        {
            EventType = eventType;
            Iteration = iteration;
            KanaryCustomResource = kanaryCustomResource;
        }

    }
}