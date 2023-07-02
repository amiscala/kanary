namespace Kanary.Domain.Entities.CustomResourceDefinitions
{
    public class KanaryStatus
    {
        public bool KanaryRunning { get; set; }
        public int KanaryDeploymentWeight { get; set; }
        public int StableDeploymentWeight { get; set; }
        public Dictionary<string,string> StableToKanaryDifferences { get; set; }
        public string State { get; set; }
        public string Message { get; set; }
        public int ObservedGeneration { get; set; }
    }
}