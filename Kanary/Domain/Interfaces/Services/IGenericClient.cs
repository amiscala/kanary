using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using k8s.Models;

namespace Kanary.Domain.Interfaces.Services
{
    public interface IGenericClient
    {
        public Task<T> CreateAsync<T>(T obj, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> CreateNamespacedAsync<T>(T obj, string ns, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> DeleteAsync<T>(string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> DeleteNamespacedAsync<T>(string ns, string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public void Dispose();
        public Task<T> ListAsync<T>(CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> ListNamespacedAsync<T>(string ns, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> PatchAsync<T>(V1Patch patch, string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> PatchNamespacedAsync<T>(V1Patch patch, string ns, string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> ReadAsync<T>(string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> ReadNamespacedAsync<T>(string ns, string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> ReplaceAsync<T>(T obj, string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public Task<T> ReplaceNamespacedAsync<T>(T obj, string ns, string name, CancellationToken cancel = default) where T : IKubernetesObject;
        public Watcher<T> Watch<T>(Action<WatchEventType, T> onEvent, Action<Exception> onError = null, Action onClosed = null) where T : IKubernetesObject;
        public IAsyncEnumerable<(WatchEventType, T)> WatchAsync<T>(Action<Exception> onError = null, CancellationToken cancel = default) where T : IKubernetesObject;
        public Watcher<T> WatchNamespaced<T>(string ns, Action<WatchEventType, T> onEvent, Action<Exception> onError = null, Action onClosed = null) where T : IKubernetesObject;
        public IAsyncEnumerable<(WatchEventType, T)> WatchNamespacedAsync<T>(string ns, Action<Exception> onError = null, CancellationToken cancel = default) where T : IKubernetesObject;
    }
}