using System;
using System.Collections.Generic;

namespace EasyTools.Framework.Application
{
    public class Resources
    {
        private static Dictionary<string, Dictionary<string, string>> resources;

        static Resources()
        {
            resources = new Dictionary<string, Dictionary<string, string>>();
        }

        public static string ResourceValue(string language, string resourceName, params string[] args)
        {
            if (resources.ContainsKey(language))
                if (resources[language].ContainsKey(resourceName))
                    return String.Format(resources[language][resourceName], args);
            return resourceName;
        }

        public static void AddResource(string language, string resourceName, string resourceValue)
        {
            if (!resources.ContainsKey(language))
                resources.Add(language, new Dictionary<string, string>());
            if (!resources[language].ContainsKey(resourceName))
                resources[language].Add(resourceName, resourceValue);
        }
    }
}