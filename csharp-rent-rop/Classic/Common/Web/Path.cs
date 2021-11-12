using System.Collections.Generic;

namespace Richargh.BillionDollar.Classic.Common.Web
{
    public class Path
    {
        public string FullPath { get; }
        private readonly Dictionary<string, string> _parameters;
        
        public Path(string fullPath, Dictionary<string, string> parameters)
        {
            FullPath = fullPath;
            _parameters = parameters;
        }
        
        public string? this[string key] => _parameters.GetValueOrDefault(key);
    }
}