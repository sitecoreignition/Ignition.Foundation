﻿using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.System
{
	[SitecoreType(TemplateId = "{6D1CD897-1936-4A3A-A511-289A94C2A7B1}")]
	public interface IDictionaryEntry : IGlassItem
	{
		string Key { get; set; }
		string Phrase { get; set; }
	}
}
