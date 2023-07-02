namespace Kanary.Domain.Entities.CustomResourceDefinitions.Spec.Pipeline.Common.SourceType
{
    public class KanaryPipelineSourceSpec
    {
        public KanaryPipelineSourceTypeEnum SourceType { get; set; }
        public string Uri { get; set; }
        public string FilePathAndName { get; set; }
        public Dictionary<string,string> Replacements { get; set; }
    }
}