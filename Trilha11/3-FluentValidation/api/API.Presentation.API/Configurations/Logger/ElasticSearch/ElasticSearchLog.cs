using System;
using System.Collections.Generic;
using System.IO;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Elasticsearch;

namespace API.Presentation.API.Configurations.Logger.ElasticSearch
{
    public class ElasticSearchLog : ExceptionAsObjectJsonFormatter
    {
        public DateTime Timetamp { get; set; }
        public string HttpMethod { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameters { get; set; }
        public string Message { get; set; }
        public string Layer { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public Dictionary<string, Object> AdditionalInfo { get; set; }
        public string Exception { get; set; }
        public long? ElapseMilliseconds { get; set; }
        public string BussinessClient { get; set; }
        public string UserIp { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        public ElasticSearchLog()
        {
            Timetamp = DateTime.Now;
            AdditionalInfo = new Dictionary<string, Object>();
        }
    }
}