using System;
using System.Collections.Generic;

namespace EasyTools.Framework.Application
{
    public class App
    {
        private static App current;

        private App()
        {
        }

        public Configuration Configuration { get; private set; }

        public static App Current
        {
            get
            {
                if (current == null)
                    current = new App();
                return current;
            }
        }

        public static void AddCurrentConfiguration(Configuration conf)
        {
            Current.Configuration = conf;
        }

        private Dictionary<Guid, UserSession> currentSessions;

        public Dictionary<Guid, UserSession> CurrentSessions
        {
            get
            {
                if (currentSessions == null)
                    currentSessions = new Dictionary<Guid, UserSession>();
                return currentSessions;
            }
            set
            {
                currentSessions = value;
            }
        }

    }
}