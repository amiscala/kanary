using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanary.Domain.Interfaces.HostedServices
{
    public interface IKanaryHostedService : IHostedService, IDisposable
    {
        
    }
}