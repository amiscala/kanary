using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanary.Config
{
    public class ApiConfig
    {
        public KanaryConfig KanaryConfig { get; set; }
        public ApiConfig()
        {
            KanaryConfig = new KanaryConfig
            {
                DisposeClient = true,
                Namespace = "default"
            };
        }
    }
    

    public class KanaryConfig
    {
        public string Group { get; set; }
        public string Version { get; set; }
        public string Plural { get; set; }
        public bool DisposeClient { get; set; }
        public string Namespace { get; set; }
    }
}