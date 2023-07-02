using Kanary.Domain.Entities.CustomResourceDefinitions.Spec.Pipeline.Common.SourceType;

namespace Kanary.Domain.Entities.CustomResourceDefinitions.Spec
{
    public class KanarySpec
    {
        public List<KanaryPipelineSourceSpec> Pipeline { get; set; }
    }
}