using System;
using System.Collections.Concurrent;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.DataMappers;
using Sitecore.Data.Fields;

namespace Ignition.Foundation.Core.GlassMapper.DataMappers
{
    public class MultiLineFieldStringMapper : SitecoreFieldStringMapper
    {
        private static readonly ConcurrentDictionary<Guid, bool> IsMultiLineDictionary = new ConcurrentDictionary<Guid, bool>();

        public override object GetField(Field field, SitecoreFieldConfiguration config,
            SitecoreDataMappingContext context)
        {
            var value = (string)base.GetField(field, config, context);

            var guid = field.ID.Guid;
            if (IsMultiLineDictionary.ContainsKey(guid) && IsMultiLineDictionary[guid])
                return FixMultiLineFieldLineBreaks(value);

            var isMultiLine = field.TypeKey == "multi-line text";
            IsMultiLineDictionary.TryAdd(guid, isMultiLine);

            if (!isMultiLine)
                return value;

            return FixMultiLineFieldLineBreaks(value);
        }

        private static string FixMultiLineFieldLineBreaks(string value)
        {
            return value?.Replace("\r\n", "<br />");
        }
    }
}