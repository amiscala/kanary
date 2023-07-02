using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using k8s;
using Kanary.Config;
using Kanary.Domain.Entities;
using Kanary.Domain.Entities.CustomResourceDefinitions;
using Kanary.Domain.Interfaces.HostedServices;
using Kanary.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kanary.HostedServices
{
    public class KanaryHostedService : IKanaryHostedService
    {

        private readonly CancellationTokenSource _cancellationTokenSource;
        private Task _executingTask;
        private readonly IKanaryClient _kanaryClient;
        private readonly ApiConfig _config;
        private readonly ILogger<KanaryHostedService> _logger;
        private readonly ActionBlock<KanaryEvent> _consumer;
        public KanaryHostedService(IKanaryClient kanaryClient, IOptions<ApiConfig> config, ILogger<KanaryHostedService> logger)
        {
            _logger = logger;
            _config = config.Value;
            _kanaryClient = kanaryClient;
            _cancellationTokenSource = new CancellationTokenSource();
            _consumer = new ActionBlock<KanaryEvent>(x => ConsumeAsync(x));
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Start the executing task
            _executingTask = WatchKanaryCRD(_cancellationTokenSource.Token);
            _ = Task.CompletedTask;
        }


        private async Task ConsumeAsync(KanaryEvent message)
        {
            // On the first iteration K8s always send all created resources to we sync them
            if (message.Iteration == 0)
            {
                await KanarySync(message);
                return;
            }
            switch (message.EventType)
            {
                case WatchEventType.Added:
                    break;
                case WatchEventType.Modified:
                    break;
                case WatchEventType.Deleted:
                    break;
                case WatchEventType.Error:
                    break;
                case WatchEventType.Bookmark:
                    break;
                default:
                    throw new Exception("Unkonw Event Type");
            }
            _logger.LogInformation(message.EventType.ToString());
            _logger.LogInformation(message.KanaryCustomResource.Metadata.Name);
            _logger.LogInformation(JsonConvert.SerializeObject(message));
        }



        private async Task WatchKanaryCRD(CancellationToken cancellationToken)
        {
            try
            {
                int iterations = 0;
                while (!_cancellationTokenSource.IsCancellationRequested)
                {

                    var watcher = _kanaryClient.WatchNamespacedAsync<KanaryCustomResource>(_config.KanaryConfig.Namespace, cancel: cancellationToken);
                    await foreach (var (type, item) in watcher)
                    {
                        await _consumer.SendAsync(new KanaryEvent(type, item, iterations));
                        iterations++;
                    }
                }

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        private Task KanarySync(KanaryEvent message)
        {
            _logger.LogInformation(message.EventType.ToString());
            _logger.LogInformation(message.KanaryCustomResource.Metadata.Name);
            _logger.LogInformation(JsonConvert.SerializeObject(message));
            return Task.CompletedTask;
        }


        public async Task StopAsync(CancellationToken cancellationToken)
        {
            // Wait for the executing task to complete
            await _executingTask;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
        }
    }

    

}