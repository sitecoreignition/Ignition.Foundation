using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Xml.Serialization;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Page;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Globalization;

namespace Ignition.Foundation.Core.Mvc
{
    public class IgnitionViewModel 
    {
        public IPage ContextPage { get; set; }
		public object GlassCssClassParameters(string cssClass) => new { @class = cssClass };
	    public object GlassImageParameters(string cssClass, int height, int width) => new { @class = cssClass, height = height.ToString(), width = width.ToString() };
	    public NameValueCollection GlassAttributeParameters(string attributeName, string attributeValue) => new NameValueCollection { { attributeName, attributeValue } };
		[SitecoreId, IndexField("_group")]
		public virtual Guid Id { get; set; }
		[SitecoreInfo(SitecoreInfoType.Language), IndexField("_language")]
		public virtual Language Language { get; set; }
		[TypeConverter(typeof(IndexFieldItemUriValueConverter)), XmlIgnore, IndexField("_uniqueid")]
		public virtual ItemUri Uri { get; set; }
		[SitecoreInfo(SitecoreInfoType.DisplayName)]
		public virtual string DisplayName { get; set; }
		[SitecoreInfo(SitecoreInfoType.Version)]
		public virtual int Version { get; set; }
		[SitecoreInfo(SitecoreInfoType.Path), IndexField("_path")]
		public virtual string Path { get; set; }
		[SitecoreInfo(SitecoreInfoType.Name), IndexField("_name")]
		public virtual string Name { get; set; }
		[SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
		public virtual string Url { get; set; }
    }
}