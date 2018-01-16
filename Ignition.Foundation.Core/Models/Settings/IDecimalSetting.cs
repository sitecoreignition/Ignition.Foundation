using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.Settings
{
	[SitecoreType(TemplateId = "{978C9A93-78C3-431D-9431-C6315FAE127F}")]
	public interface IDecimalSetting : IGlassItem
	{
		[SitecoreField(FieldId = "{D7E2526E-9703-4EC7-A7C1-449E7C1134F6}")]
		decimal DecimalSetting { get; set; }
	}
}
