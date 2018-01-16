﻿using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.Settings
{
	[SitecoreType(TemplateId = "{4DCC294F-D5EC-4607-917A-E4A3B80EC624}")]
	public interface IStringSetting : IGlassItem
	{
		[SitecoreField(FieldId = "{0DBDC181-2CD0-4FEA-B8F1-763888684F41}")]
		string StringSetting { get; set; }
	}
}
