using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Globalization;

namespace Ignition.Foundation.Core.Mvc
{
	public class IgnitionModel
	{
		[SitecoreId, IndexField("_group")]
		public virtual Guid Id { get; set; }

		[SitecoreInfo(SitecoreInfoType.Language), IndexField("_language")]
		public virtual Language Language { get; set; }

		[TypeConverter(typeof(IndexFieldItemUriValueConverter)), XmlIgnore, IndexField("_uniqueid")]
		public virtual ItemUri Uri { get; set; }

		[SitecoreInfo(SitecoreInfoType.DisplayName), IndexField("_displayname")]
		public virtual string DisplayName { get; set; }

		[SitecoreInfo(SitecoreInfoType.Version), IndexField("_version")]
		public virtual int Version { get; set; }

		[SitecoreInfo(SitecoreInfoType.Path), IndexField("_path")]
		public virtual string Path { get; set; }

		[SitecoreInfo(SitecoreInfoType.Name), IndexField("_name")]
		public virtual string Name { get; set; }

		[SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
		public virtual string Url { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId), IndexField("_template")]
        public virtual Guid TemplateId { get; set; }
	}
}