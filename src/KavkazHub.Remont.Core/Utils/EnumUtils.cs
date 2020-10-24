using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KavkazHub.Remont.Core.Utils
{
    public class EnumUtils
    {
        private readonly IModelMetadataProvider _provider;
        public EnumUtils(IModelMetadataProvider provider)
        {
            _provider = provider;
        }

        public List<string> EnumToListItems<TEnum>() where TEnum : struct
        {
            var metadata = _provider.GetMetadataForType(typeof(TEnum));
            var keyArray = metadata.EnumNamesAndValues.Keys.ToArray();
            List<string> items = metadata.EnumGroupedDisplayNamesAndValues
                .Select(x => x.Key.Name).ToList();
            return items;
        }
        public List<string> EnumToListItems(Type enumType)
        {
            var metadata = _provider.GetMetadataForType(enumType);
            List<string> items = metadata.EnumGroupedDisplayNamesAndValues?
                .Select(x => x.Key.Name).ToList();
            return items;
        }
    }
}
