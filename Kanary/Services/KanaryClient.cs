using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using k8s.Models;
using Kanary.Config;
using Kanary.Domain.Entities.CustomResourceDefinitions;
using Kanary.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace Kanary.Services
{
    public class KanaryClient : GenericClient, IKanaryClient
    {
        private readonly IKubernetes _k8sClient;
        private readonly ApiConfig _config;
        public KanaryClient(IKubernetes kubernetes,
                            IOptions<ApiConfig> config)
                            : base(
                                kubernetes,
                                config.Value.KanaryConfig.Group,
                                config.Value.KanaryConfig.Version,
                                config.Value.KanaryConfig.Plural)
        {
            _k8sClient = kubernetes;
            _config = config.Value;
        }

        public IAsyncEnumerable<(WatchEventType, KanaryCustomResource)> WatchNamespacedAsyncFull(bool? allowWatchBookmarks = null,
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
                                                                                             CancellationToken cancellationToken = default)
        {

            var respTask = _k8sClient.CustomObjects.ListNamespacedCustomObjectWithHttpMessagesAsync(
                _config.KanaryConfig.Group,
                _config.KanaryConfig.Version,
                _config.KanaryConfig.Namespace,
                _config.KanaryConfig.Plural,
                allowWatchBookmarks,
                continueParameter,
                fieldSelector,
                labelSelector,
                limit,
                resourceVersion,
                resourceVersionMatch,
                timeoutSeconds,
                true,
                pretty,
                customHeaders,
                cancellationToken);
            return respTask.WatchAsync<KanaryCustomResource, object>();
        }

    }
}
