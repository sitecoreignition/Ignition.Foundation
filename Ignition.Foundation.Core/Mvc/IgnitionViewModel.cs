using System.Collections.Specialized;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Mvc
{
	[SitecoreType(TemplateId = "{4C3CDC24-1610-4808-92A3-A221768AE3B2}", AutoMap = true)]
	public class IgnitionViewModel  : IgnitionModel
    {

	    public IPage ContextPage { get; set; }
		public object GlassCssClassParameters(string cssClass) => new { @class = cssClass };
	    public object GlassImageParameters(string cssClass, int height, int width) => new { @class = cssClass, height = height.ToString(), width = width.ToString() };
	    public NameValueCollection GlassAttributeParameters(string attributeName, string attributeValue) => new NameValueCollection { { attributeName, attributeValue } };
    }
}