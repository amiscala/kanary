using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanary.Domain.Entities;
using Kanary.Domain.Interfaces.Pipelines;

namespace Kanary.Pipelines
{
    /// <summary>
    /// Pipeline used when a Kanary Resource promotion is requested, this pipeline is responsible to set 100% of the trafic to the -canary deployment, them updates the stable deployment to the same as the Canary
    /// after all pods inside the deployment were recicled, sets back all the trafic to the stable deployment, cleans up the -canary resources and updates the Kanary inside the k8s and k8s.
    /// </summary>
    public class PromotionPipeline : IPromotionPipeline
    {
        public Task<bool> Enqueue(KanaryEvent message)
        {
            throw new NotImplementedException();
        }
    }
}