using System;
using AdapterPattern.Adapters;
using AdapterPattern.Services;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlConverter = new XmlConverter();
            var adapter = new XmlToJsonAdapter(xmlConverter);
            adapter.ConvertXmlToJson();
        }
    }
}
