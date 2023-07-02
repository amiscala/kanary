using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanary.Domain.Entities.CustomResourceDefinitions.Spec.Pipeline.Common.SourceType;

namespace Kanary.Domain.Interfaces.Infrastructure
{
    ///<summary>
    /// Interface responsible to download the files from the repository it implements, this will be used by the IPipelineService implementation
    /// and the implementation will be used on the Pipelines (Creation, Update, Deletion and Promotion)
    ///</summary>
    public interface IKanaryPipelineSourceRepository
    {
        Task<string> DownloadFileFromRepository(KanaryPipelineSourceSpec pipelineSource);
    }
}