using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanary.Domain.Entities;
using Kanary.Domain.Interfaces.Pipelines;

namespace Kanary.Pipelines
{
    /// <summary>
    /// Pipeline used when a new Kanary Resource is deleted, this pipeline is responsible to clean the Kanary from the persistance system
    /// the persistance picked, check if the resources inside the Pipeline itens have been already created, if not, apply them, saves the new state into K8s and persisntance
    /// </summary>
    public class DeletionPipeline : IDeletionPipeline
    {
        public Task<bool> Enqueue(KanaryEvent message)
        {
            throw new NotImplementedException();
        }
    }
}