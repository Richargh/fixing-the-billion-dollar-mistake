using System.Collections.Generic;
using System.Linq;

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
        
        public Path(string fullPath, params (string, string)[] parameters) : this(
            fullPath, 
            new Dictionary<string, string>(parameters.Select(pair => new KeyValuePair<string, string>(pair.Item1, pair.Item2))))
        {
        }
        
        public string? this[string key] => _parameters.GetValueOrDefault(key);
    }
}