using System.Collections.Generic;

namespace API.Presentation.API.Configurations.Logger.ElasticSearch
{
    public class ElasticSearchLoggerConfig
    {
        public string FilePathFormat { get; set; }
        public string ElasticSearchUri { get; set; }
        public string KibanaUri { get; set; }
        public string ElasticSearchUserName { get; set; }
        public string ElasticSearchUserPassword { get; set; }
        public bool WriteDiagnostics { get; set; }
    }
}