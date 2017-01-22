<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <settings>
      <setting name="Publishing.PublishEmptyItems">
        <patch:attribute name="value">true</patch:attribute>
      </setting>
    </settings>

    <pipelines>
		<getPlaceholderRenderings>
			<processor
			  type="Ignition.Foundation.Core.DynamicPlaceholders.GetDynamicKeyAllowedRenderings, Ignition.Foundation.Core"
			  patch:before="processor[@type='Sitecore.Pipelines.GetPlaceholderRenderings.GetAllowedRenderings, Sitecore.Kernel']"/>
		</getPlaceholderRenderings>
		<getChromeData>
			<processor
			  type="Ignition.Foundation.Core.DynamicPlaceholders.GetDynamicPlaceholderChromeData, Ignition.Foundation.Core"
			  patch:after="processor[@type='Sitecore.Pipelines.GetChromeData.GetPlaceholderChromeData, Sitecore.Kernel']"/>
		</getChromeData>
		<initialize>
        <processor type="Ignition.Foundation.CompositionRoot.IgnitionGlassLoaders, Ignition.Foundation.CompositionRoot" patch:after="processor[@type='$rootnamespace$.App_Start.GlassMapperSc, $assemblyname$']"/>
        <processor type="Ignition.Foundation.CompositionRoot.InitializeDependencyResolver, Ignition.Foundation.CompositionRoot" patch:before="processor[@type='Sitecore.Mvc.Pipelines.Loader.InitializeControllerFactory, Sitecore.Mvc']"/>
        <processor type="Ignition.Foundation.CompositionRoot.InitializeViewEngines, Ignition.Foundation.CompositionRoot" patch:after="processor[@type='Sitecore.Mvc.Pipelines.Loader.InitializeRoutes, Sitecore.Mvc']"/>
        <processor type="Ignition.Foundation.CompositionRoot.InitializeRoutes, Ignition.Foundation.CompositionRoot" patch:after="processor[@type='Sitecore.Mvc.Pipelines.Loader.InitializeGlobalFilters, Sitecore.Mvc']"/>
      </initialize>
    </pipelines>
  </sitecore>
</configuration>
