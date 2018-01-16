using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ignition.Foundation.Core.Automap
{
  public static class IgnitionAutomapHelper
  {
    public static IEnumerable<Assembly> GetAutomappedAssemblies()
    {
      var automappedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
        .Select(Assembly.Load)
        .Where(IsAutomappedAssembly)
        .ToList();

      // load possible standalone assemblies
      automappedAssemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies()
        .Where(IsAutomappedAssembly)
        .Where(a => !automappedAssemblies.Contains(a))
        .Select(a => Assembly.Load(a.FullName)));

      return automappedAssemblies.ToList();
    }

    public static IEnumerable<Assembly> GetAutomappedAssembliesInCurrentDomain()
    {
      var automappedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(IsAutomappedAssembly)
        .Select(a => Assembly.Load(a.FullName));
      return automappedAssemblies.ToList();
    }

    public static bool IsAutomappedAssembly(Assembly assembly)
    {
      return assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any();
    }
  }
}
