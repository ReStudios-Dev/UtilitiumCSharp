using System.Collections.Generic;
using System.Linq;

namespace org.ReStudios.utitlitium
{
    public class BetterArguments
    {
        private readonly Dictionary<string, string> arguments;
        private readonly Dictionary<string, string> defaultArguments;

        /// <summary>
        /// Пример:
        /// <code>
        /// public static void Main(string[] args){
        ///     BetterArguments ba = new BetterArguments(args);
        ///     // ...
        /// }
        /// </code>
        /// </summary>
        /// <param name="args">Аргументы метода Main</param>

        public BetterArguments(string[] args)
        {
            arguments = new Dictionary<string, string>();
            defaultArguments = new Dictionary<string, string>();
            string key = "";
            var values = new List<string>();
            if (args.Length == 0) return;
            foreach (var arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    if (!string.IsNullOrEmpty(key))
                    {
                        arguments[key.Substring(1)] = string.Join(" ", values);
                        values = new List<string>();
                    }
                    key = arg;
                    continue;
                }
                values.Add(arg);
            }
            arguments[key.Substring(1)] = string.Join(" ", values);
        }

        public static BetterArguments Parse(string[] args)
        {
            return new BetterArguments(args);
        }

        public BetterArguments PutDefault(string key, string value)
        {
            defaultArguments[key] = value;
            return this;
        }

        public string RemoveDefault(string key)
        {
            defaultArguments.TryGetValue(key, out var value);
            defaultArguments.Remove(key);
            return value;
        }

        public string GetDefault(string key)
        {
            defaultArguments.TryGetValue(key, out var value);
            return value;
        }

        public bool ContainsDefault(string key)
        {
            return defaultArguments.ContainsKey(key);
        }

        public bool Contains(string key)
        {
            return arguments.ContainsKey(key);
        }

        public bool GetBoolean(string key)
        {
            if (!Contains(key))
            {
                if (ContainsDefault(key)) return bool.Parse(GetDefault(key));
                return false;
            }
            return GetString(key).Equals("true", System.StringComparison.OrdinalIgnoreCase);
        }

        public string GetOrShort(string full, string shortKey)
        {
            full = "-" + full;
            if (!Contains(full) && !Contains(shortKey))
            {
                if (ContainsDefault(full)) return GetDefault(full);
                if (ContainsDefault(shortKey)) return GetDefault(shortKey);
                return "";
            }
            return Contains(full) ? GetString(full) : Contains(shortKey) ? GetString(shortKey) : "";
        }

        public string GetString(string key)
        {
            if (!Contains(key))
            {
                if (ContainsDefault(key)) return GetDefault(key);
                else return "";
            }
            return arguments[key];
        }

        public int GetInteger(string key)
        {
            return GetIntegerOr(key, -1);
        }

        public int GetIntegerOr(string key, int i)
        {
            return Contains(key) ? int.TryParse(GetString(key), out int result) ? result : 0 :
                                    ContainsDefault(key) ? int.TryParse(GetDefault(key), out result) ? result : 0 : i;
        }

        public override string ToString()
        {
            var values = new List<string>();
            foreach (var kv in arguments)
            {
                if (string.IsNullOrEmpty(kv.Value))
                {
                    values.Add(kv.Key);
                }
                else
                {
                    values.Add(kv.Key + "=" + "'" + kv.Value.Replace("\"", "\\\"") + "'");
                }
            }
            return "{" + string.Join(", ", values) + "}";
        }
    }
}
