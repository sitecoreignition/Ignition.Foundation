using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Glass.Mapper.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Attributes;
using Sitecore.Pipelines;

namespace Ignition.Foundation.CompositionRoot.App_Start
{
    public class IgnitionGlassLoaders
    {
        public void Process(PipelineArgs args)
        {
            Glass.Mapper.Context.Default.Load(GlassLoaders());
        }

        public static IConfigurationLoader[] GlassLoaders()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(assembly => assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any())
                    .Select(a => Assembly.Load(a.FullName)).ToList();
            return assemblies.Select(a => new SitecoreAttributeConfigurationLoader(a.GetName().ToString().Substring(0, a.GetName().ToString().IndexOf(",")))).ToArray();
        }
    }
}