using System;

namespace Ignition.Foundation.Mvc.Mvc
{
	public interface IIgnitionModel
	{
		Guid Id { get; set; }
		Guid TemplateId { get; set; }
		string Name { get; set; }
		string DisplayName { get; set; }
		int Version { get; set; }
		string Language { get; set; }
		string Path { get; set; }
		string Url { get; set; }
	}
}
