using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanary.Domain.Entities;
using Kanary.Domain.Interfaces.Pipelines;

namespace Kanary.Pipelines
{
    /// <summary>
    /// Pipeline used when a new Kanary Resource already exits on the, this pipeline is responsible to check whether or not the Canary process is running for the instance, if it is running ignores the event
    /// if not, starts the Canary process creation, such as creating the resources from the "pipeline" property from the Kanary YAML/JSON with the -canary sufix, saving the status to K8s and Database.
    /// </summary>
    public class UpdatePipeline : IUpdatePipeline
    {
        public Task<bool> Enqueue(KanaryEvent message)
        {
            throw new NotImplementedException();
        }
    }
}