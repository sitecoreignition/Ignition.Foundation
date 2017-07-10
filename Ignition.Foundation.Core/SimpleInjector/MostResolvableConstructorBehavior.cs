using System;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Advanced;

namespace Ignition.Foundation.Core.SimpleInjector
{
    public class MostResolvableConstructorBehavior : IConstructorResolutionBehavior
    {
        private readonly Container _container;

        public MostResolvableConstructorBehavior(Container container)
        {
            _container = container;
        }

        private bool IsCalledDuringRegistrationPhase => !_container.IsLocked();

        public ConstructorInfo GetConstructor(Type implementation)
        {
            var constructors = implementation.GetConstructors();
            if (!constructors.Any()) return null;

            return constructors.Select(constructor => new {constructor, parameters = constructor.GetParameters()})
	            .Where(t => IsCalledDuringRegistrationPhase
	                         || constructors.Length == 1
	                         || t.parameters.All(CanBeResolved))
	            .OrderByDescending(t => t.parameters.Length)
	            .Select(t => t.constructor)
                .First();
        }
        private bool CanBeResolved(ParameterInfo p)
        {
            return _container.GetRegistration(p.ParameterType) != null || CanBuildType(p);
        }
        private bool CanBuildType(ParameterInfo p)
        {
            try
            {
                _container.Options.DependencyInjectionBehavior.GetInstanceProducer(new InjectionConsumerInfo(p), false);
                return true;
            }
            catch (ActivationException)
            {
                return false;
            }
        }
    }
}