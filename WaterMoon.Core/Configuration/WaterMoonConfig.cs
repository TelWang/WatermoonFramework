using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WaterMoon.Core.Configuration
{
    public class WaterMoonConfig : IConfigurationSectionHandler
    {
        private static WaterMoonConfig defaut = new WaterMoonConfig()
        {
            DynamicDiscovery = true,
            EngineType = null,
            IgnoreStartupTasks = false
        };

        public static WaterMoonConfig Defaut
        {
            get { return WaterMoonConfig.defaut; }
        }

        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new WaterMoonConfig();
            var dynamicDiscoveryNode = section.SelectSingleNode("DynamicDiscovery");
            if (dynamicDiscoveryNode != null && dynamicDiscoveryNode.Attributes != null)
            {
                var attribute = dynamicDiscoveryNode.Attributes["Enabled"];
                if (attribute != null)
                    config.DynamicDiscovery = Convert.ToBoolean(attribute.Value);
            }

            var engineNode = section.SelectSingleNode("Engine");
            if (engineNode != null && engineNode.Attributes != null)
            {
                var attribute = engineNode.Attributes["Type"];
                if (attribute != null)
                    config.EngineType = attribute.Value;
            }

            var startupNode = section.SelectSingleNode("Startup");
            if (startupNode != null && startupNode.Attributes != null)
            {
                var attribute = startupNode.Attributes["IgnoreStartupTasks"];
                if (attribute != null)
                    config.IgnoreStartupTasks = Convert.ToBoolean(attribute.Value);
            }

            return config;
        }

        /// <summary>
        /// In addition to configured assemblies examine and load assemblies in the bin directory.
        /// </summary>
        public bool DynamicDiscovery { get; private set; }

        /// <summary>
        /// A custom <see cref="IEngine"/> to manage the application instead of the default.
        /// </summary>
        public string EngineType { get; private set; }

        /// <summary>
        /// Indicates whether we should ignore startup tasks
        /// </summary>
        public bool IgnoreStartupTasks { get; private set; }
    }
}
