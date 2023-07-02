using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanary.Domain.Entities.CustomResourceDefinitions;

namespace Kanary.Domain.Interfaces.Infrastructure
{
    public interface IKanaryPersistanceService
    {
        Task<KanaryCustomResource> GetKanaryCustomResource(string name);
        Task InsertKanaryCustomResource(KanaryCustomResource resource);
        Task UpdateKanaryCustomResource(KanaryCustomResource resource);
        Task DeleteKanaryCustomResource(KanaryCustomResource resource);
    }
}