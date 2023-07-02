using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Kanary.Domain.Entities.CustomResourceDefinitions.Abstract;
using Kanary.Domain.Entities.CustomResourceDefinitions.Spec;

namespace Kanary.Domain.Entities.CustomResourceDefinitions
{
    public class KanaryCustomResource : CustomResource
    {
        [JsonPropertyName("spec")]
        public KanarySpec Spec { get; set; }

        [JsonPropertyName("CStatus")]
        public KanaryStatus CStatus { get; set; }
    }
}