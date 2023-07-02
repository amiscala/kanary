using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Kanary.Domain.Entities;

namespace Kanary.Domain.Interfaces.Pipelines
{
    public interface IKanaryPipeline
    {
        public Task<bool> Enqueue(KanaryEvent message);
    }
}