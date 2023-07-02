using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Kanary.Domain.Entities.CustomResourceDefinitions;

namespace Kanary.Domain.Interfaces.Services
{
    public interface IKanaryClient : IGenericClient
    {
        public IAsyncEnumerable<(WatchEventType, KanaryCustomResource)> WatchNamespacedAsyncFull(
                                                                                             bool? allowWatchBookmarks = null,
                                                                                             string continueParameter = null,
                                                                                             string fieldSelector = null,
                                                                                             string labelSelector = null,
                                                                                             int? limit = null,
                                                                                             string resourceVersion = null,
                                                                                             string resourceVersionMatch = null,
                                                                                             int? timeoutSeconds = null,
                                                                                             bool? watch = null,
                                                                                             bool? pretty = null,
                                                                                             IReadOnlyDictionary<string, IReadOnlyList<string>> customHeaders = null,
                                                                                             CancellationToken cancellationToken = default);
                                                                                             
    }
}