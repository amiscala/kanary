using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanary.Domain.Entities;
using Kanary.Domain.Interfaces.Pipelines;

namespace Kanary.Pipelines
{
    /// <summary>
    /// Pipeline used when a new Kanary Resource is created, this pipeline is responsible to persist the Kanary into the 
    /// the persistance picked, check if the resources inside the Pipeline itens have been already created, if not, apply them and saves the new state into K8s and persisntance
    /// </summary>
    public class CreationPipeline : ICreationPipeline
    {
        public Task<bool> Enqueue(KanaryEvent message)
        {
            throw new NotImplementedException();
        }
    }
}